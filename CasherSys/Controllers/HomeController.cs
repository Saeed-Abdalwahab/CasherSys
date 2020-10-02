using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasherSys.Models;
using Repos.Abstraction;
using DAL;
using Services.Abstraction;
using Microsoft.AspNetCore.Authorization;

namespace CasherSys.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IitemCategoryService service;

        public HomeController(ILogger<HomeController> logger, IitemCategoryService service)
        {
            _logger = logger;
            this.service = service;

        }
        public IActionResult Index()
        {
            itemCategory itemCategory = new itemCategory();
            itemCategory.Name = "لحوم";
             //service.(itemCategory);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
