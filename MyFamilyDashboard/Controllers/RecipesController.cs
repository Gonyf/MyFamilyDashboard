using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyFamilyDashboard.Data;
using MyFamilyDashboard.Models;

namespace MyFamilyDashboard.Controllers
{
    public class RecipesController : Controller
    {
        #region protected members
        protected ApplicationDbContext applicationDbContext;

        #endregion

        public RecipesController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }
        // Recipes/Random
        public IActionResult Random()
        {
            var setting = applicationDbContext.Settings.FirstOrDefault();
            string settingName = "No settings content";
            
            if (setting != null)
            {
                settingName = setting.Name;
                setting.Name = "Horse";
                applicationDbContext.Settings.Update(setting);
                applicationDbContext.SaveChanges();
            }
            else
            {
                applicationDbContext.Settings.Add(new SettingsDataModel
                {
                    Name = "Dennis",
                    Value = "2"
                });
                applicationDbContext.SaveChanges();
            }
            
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
                    },
                    new Ingredient()
                    {
                        Name = settingName,
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