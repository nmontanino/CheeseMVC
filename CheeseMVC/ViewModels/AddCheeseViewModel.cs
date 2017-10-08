﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            { 
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }
        public AddCheeseViewModel() { }

        public static Cheese CreateCheese(AddCheeseViewModel addCheeseVM, CheeseCategory newCheeseCategory)
        {
            Cheese newCheese = new Cheese
            {
                Name = addCheeseVM.Name,
                Description = addCheeseVM.Description,
                Category = newCheeseCategory,
                Rating = addCheeseVM.Rating
            };

            return newCheese;
        }
    }
}
