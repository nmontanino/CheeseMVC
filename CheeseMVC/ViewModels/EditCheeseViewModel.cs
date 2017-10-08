using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel : AddCheeseViewModel
    {
        public int ID { get; set; }

        public static EditCheeseViewModel EditCheese(Cheese cheese)
        {

            EditCheeseViewModel edit = new EditCheeseViewModel
            {
                ID = cheese.ID,
                Name = cheese.Name,
                Description = cheese.Description,
                Rating = cheese.Rating,
                CategoryID = cheese.CategoryID
            };

            return edit;
        }
    }
}
