using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public static AddEditCheeseViewModel EditCheese(Cheese cheese)
        {
            AddEditCheeseViewModel edit = new AddEditCheeseViewModel
            {
                Name = cheese.Name,
                Description = cheese.Description,
                Type = cheese.Type,
                Rating = cheese.Rating
            };

            return edit;
        }
    }
}
