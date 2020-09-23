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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reports.DevExpressReports.Order;
using Repos.Abstraction;
using Services.Abstraction;
using Statics;

namespace CasherSys.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService service;

        private readonly IitemCategoryService ItemCategoryService;
        private readonly IRepository<Item> itemRepo;
        private readonly IRepository<LoafType> loaftypeRepo;

        public OrderController(IOrderService service, IitemCategoryService ItemCategoryService,IRepository<Item> ItemRepo,IRepository<LoafType> loaftypeRepo)
        {
            this.service = service;

            this.ItemCategoryService = ItemCategoryService;
            itemRepo = ItemRepo;
            this.loaftypeRepo = loaftypeRepo;
        }
       
        public IActionResult Index()
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
            return null;
        }
        [HttpGet]
        public void PrintOrderReport(int OrderID)
        {
            List<OrderReportVM> list = new List<OrderReportVM>();
            OrderReportVM orderReportVM = new OrderReportVM();

            var Order = service.GetOrder(OrderID);
            orderReportVM.orderDetailsVMs = Order.OrderDetails.Select(x=>new orderDetailsVM { 
             count=x.count,
             LoafTypeName=x.LoafType.Name,
             notes=x.notes,
             ItemName=x.ItemDetails.Item.Name,
             totalPrice=x.totalPrice,
             ItemPrice=x.ItemDetails.Price.ToString()
            }).ToList();


            orderReportVM.OrderNumber = Order.OrderNumberForShift.ToString();
            orderReportVM.Date = Order.Date.ToString("dd/MM/yyyy");

            orderReportVM.Time = Order.Date.ToShortTimeString();
            orderReportVM.CasherName = "Mohanad";
            orderReportVM.InvoiceCoast = Order.TotalCoast;
            XtraReport report = new OrderReport();
            
            report.DataSource = new List<OrderReportVM>() { orderReportVM };
            //report.ReportUnit = ReportUnit.HundredthsOfAnInch;
            //report.pap = 945;
            report.RollPaper = true;
            var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\ReportsPDf\");

            report.ExportToPdf(path+ report.Name+"_"+Order.OrderNumberForShift+ ".pdf");

            report.CreateDocument();
            PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
            tool.Print();
        }
    }
}