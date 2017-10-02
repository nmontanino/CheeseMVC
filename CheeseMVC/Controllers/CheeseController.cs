using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add new cheese to existing cheeses
                Cheese newCheese = AddCheeseViewModel.CreateCheese(addCheeseViewModel);
                CheeseData.Add(newCheese);

                return Redirect("/");
            }
            return View(addCheeseViewModel);
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

        public IActionResult Edit(int cheeseId)
        {
            Cheese cheeseEdit = CheeseData.GetById(cheeseId);
            AddEditCheeseViewModel addEditVM = AddEditCheeseViewModel.EditCheese(cheeseEdit);
            return View(addEditVM);
        }

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditVM)
        {
            if (ModelState.IsValid)
            {
                // Update cheese name and descriptions
                Cheese updatedCheese = CheeseData.GetById(addEditVM.CheeseId);
                updatedCheese.Name = addEditVM.Name;
                updatedCheese.Description = addEditVM.Description;
                updatedCheese.Rating = addEditVM.Rating;
                updatedCheese.Type = addEditVM.Type;
                return Redirect("/");
            }
            else
            {
                return View(addEditVM);
            }        
        }
    }
}
