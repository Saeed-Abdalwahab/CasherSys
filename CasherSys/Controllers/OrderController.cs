using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using DAL;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public void PrintOrderReport(int OrderID)
        {

        }
    }
}