using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /Menu/
        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        // GET: /Menu/Add
        public IActionResult Add()
        {
            AddMenuViewModel addMenuVM = new AddMenuViewModel();
            return View(addMenuVM);
        }
        
        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuVM)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuVM.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();
                return Redirect($"/Menu/ViewMenu/{newMenu.ID}");
            }
            return View(addMenuVM);
        }
        
        public IActionResult ViewMenu(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            ViewMenuViewModel viewMenuVM = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };
            return View(viewMenuVM);
        }

        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Cheese> cheeses = context.Cheeses.ToList();
            AddMenuItemViewModel addMenuItemVM = new AddMenuItemViewModel(menu, cheeses);
            return View(addMenuItemVM);
        }
        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemVM)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save changes to context and redirect back to /Menu
            }
            return View(addMenuItemVM);
        }
    }
}
