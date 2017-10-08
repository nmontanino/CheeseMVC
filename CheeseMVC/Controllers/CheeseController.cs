using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();
            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = 
                new AddCheeseViewModel(context.Categories.ToList());

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseVM)
        {
            if (ModelState.IsValid)
            {
                //Add new cheese to existing cheeses
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addCheeseVM.CategoryID);

                Cheese newCheese = AddCheeseViewModel.CreateCheese(addCheeseVM, newCheeseCategory);
                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/");
            }
            return View(addCheeseVM);
        }
        
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            // Remove cheese from existing cheeses
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }
            context.SaveChanges();
            return Redirect("/");
        }
        public IActionResult Edit(int cheeseId)
        {
            Cheese cheeseEdit = context.Cheeses.Single(c => c.ID == cheeseId);

            EditCheeseViewModel editCheeseVM = EditCheeseViewModel.EditCheese(cheeseEdit);
            return View(editCheeseVM);
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseVM)
        {
            if (ModelState.IsValid)
            {
                // Update cheese name and descriptions
                Cheese updatedCheese = context.Cheeses.Single(c => c.ID == editCheeseVM.ID);
                context.Cheeses.Update(updatedCheese);

                // TODO: Add edit for categories
                updatedCheese.Name = editCheeseVM.Name;
                updatedCheese.Description = editCheeseVM.Description;
                updatedCheese.Rating = editCheeseVM.Rating;

                context.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View(editCheeseVM);
            }
        }
    }
}
