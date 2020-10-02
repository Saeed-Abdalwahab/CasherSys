using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using DAL;
using DAL.ViewModels;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reports.DevExpressReports.Order;
using Repos.Abstraction;
using Services.Abstraction;
using Statics;

namespace CasherSys.Controllers
{
 
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService service;
        private readonly IitemCategoryService ItemCategoryService;
        private readonly IRepository<Item> itemRepo;
        private readonly IRepository<LoafType> loaftypeRepo;

        public OrderController(IOrderService service, IitemCategoryService ItemCategoryService,IRepository<Item> ItemRepo,
                              IRepository<LoafType> loaftypeRepo)
        {
            this.service = service;
            this.ItemCategoryService = ItemCategoryService;
            itemRepo = ItemRepo;
            this.loaftypeRepo = loaftypeRepo;
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult MakeOrder()
        {
            return View(service.GetOrderCreate());
        }
        public IActionResult GetItemsTree()
        {
            return Json(ItemCategoryService.GetItemsTreeitem());
        }

        [HttpPost]
        public IActionResult ItemDetailsRow(int id)
        {
            ViewBag.LoafTypes = loaftypeRepo.GetAll().ToList();

            var Item= itemRepo.Get(id);
            
            return PartialView(Item);
        }
        [HttpPost]
        public IActionResult SaveOrder(OrderVM orderVM)
        {
          var s=  service.SaveOrderInDb(orderVM);
            return Ok();
        }

        public IActionResult PrintOrder(int OrderID)
        {
            PrintOrderReport(OrderID);
            return Ok();
        }
        private void PrintOrderReport(int OrderID)
        {
           
            XtraReport report = new OrderReport();
            report.DataSource = service.OrderReportSource(OrderID);
            report.RollPaper = true;
            //var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\ReportsPDf\");
            //report.ExportToPdf(path +  Order.OrderNumberForShift + ".pdf");
            //report.CreateDocument();
            try { 
            PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
            tool.Print();
            }
            catch
            {

            }
        }

        public IActionResult ToDayOrders()
        {
        
            var Data = service.AllToDayOrders().Select(x => new
            {
                ID = x.ID,
                Date = x.Date.ToString("yyyy/MM/dd"),
                Time=x.Date.ToString("HH:mm"),
                TotalCost = x.TotalCoast,
                OrderNumber = x.OrderNumberForShift,
            }).ToList();
            return Ok(new { data= Data });
        }
        public PartialViewResult GetReport(int OrderID)
        {
            XtraReport report = new OrderReport();
            report.DataSource = service.OrderReportSource(OrderID);
            report.RollPaper = true;
            

            report.CreateDocument();
            try
            {
                PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
                tool.Print();
            }
            catch
            {

            }
            return PartialView(report);
        }
    }
}