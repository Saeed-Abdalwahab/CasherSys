using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstraction;

namespace CasherSys.Controllers
{
    public class ItemCategoryController : Controller
    {
        private readonly IitemCategoryService service;

        public ItemCategoryController(IitemCategoryService iitemCategoryService)
        {
            this.service = iitemCategoryService;
        }
        public JsonResult GetallCategories()
        {
            return Json(service.Getall());
        }
    }
}