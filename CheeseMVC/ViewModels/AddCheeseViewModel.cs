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

        public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            foreach (CheeseType type in Enum.GetValues(typeof(CheeseType)))
            {
                CheeseTypes.Add(new SelectListItem
                {
                    Value = ((int)type).ToString(),
                    Text = type.ToString()
                });
            }
        }
        public static Cheese CreateCheese(AddCheeseViewModel i)
        {
            Cheese newCheese = new Cheese
            {
                Name = i.Name,
                Description = i.Description,
                Type = i.Type,
                Rating = i.Rating
            };

            return newCheese;
        }
    }
}