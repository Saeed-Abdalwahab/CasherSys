using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace CasherSys.Controllers
{
    public class DailyExpensesController : Controller
    {
        private readonly IDailyExpensesService service;

        public DailyExpensesController(IDailyExpensesService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetData()
        {
            return Ok(new { data = service.all().ToList().Select(x=>new
            {
                id=x.ID,
                description=x.Description,
                time=x.Date.ToString("HH:mm"),
                date =x.Date.ToString("yyyy/MM/dd")
            }) }) ;
        }
    }
}
