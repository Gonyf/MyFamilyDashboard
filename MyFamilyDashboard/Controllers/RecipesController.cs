﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFamilyDashboard.Models;

namespace MyFamilyDashboard.Controllers
{
    public class RecipesController : Controller
    {
        // Recipes/Random
        public IActionResult Random()
        {
            var recipe = new Recipe()
            {
                Name = "Butter Chicken",
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        Name = "butter",
                        Quantity = 100,
                        Unit = IngredientUnit.Grams
                    },
                    new Ingredient()
                    {
                        Name = "Chicken",
                        Quantity = 1000,
                        Unit = IngredientUnit.Grams
                    }
                }
            };
            return View(recipe);
        }
        [Route("Recipes/released/{year}/{month}")]
        public ActionResult ByRelease(int year, int month)
        {
            return Content($"Year: {year} and month: {month}");
        }
    }
}