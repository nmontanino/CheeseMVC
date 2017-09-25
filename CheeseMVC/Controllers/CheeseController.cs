using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            //Add new cheese to existing cheeses
            CheeseData.Add(newCheese);

            return Redirect("/");
        }
        
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            // Remove cheese from existing cheeses
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }
    }
}
