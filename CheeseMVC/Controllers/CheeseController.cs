using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        static private string Error = null;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.error = Error;
            return View();
        }

        [HttpPost]
        [Route("Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            //Add new cheese to existing cheeses
            if (name == null)
            {
                Error = "Name is required.";
                return Redirect("/Cheese/Add");
            }
            else
            {
                Cheeses.Add(name, description);
                Error = null;
                return Redirect("/Cheese");
            }
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("Cheese/Remove")]
        public IActionResult RemoveCheese(string[] names)
        {
            // Remove cheese from existing cheeses
            foreach (string name in names)
            {
                Cheeses.Remove(name);
            }
            
            return Redirect("/Cheese");
        }
    }
}
