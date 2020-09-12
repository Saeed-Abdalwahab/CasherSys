using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace CasherSys.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService service;

        public ItemController(IItemService service)
        {
            this.service = service;
        }

      
        [HttpGet]
        public JsonResult GetallItems()
        {
            return Json(service.Getall());
        }   
        [HttpGet]
        public JsonResult GetallItemsByCategoryID(int id)
        {
            return Json(service.GetItemsByCategoryID(id));
        }  
        [HttpGet]
        public JsonResult CategoryID(int id)
        {
            return Json(service.CategoryID(id));
        }

        [HttpGet]
        public JsonResult ItemSizes(int id)
        {
            return Json(service.ItemSizes(id));
        }
        [HttpGet]
        public JsonResult GetItemPrice(int ItemDetailsid)
        {
            return Json(service.ItemPrice(ItemDetailsid));
        }


    }
}