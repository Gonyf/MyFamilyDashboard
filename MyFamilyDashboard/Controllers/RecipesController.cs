using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFamilyDashboard.Data;

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
        public IActionResult Index()
        {
            return View(applicationDbContext.Recipes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RecipeDataModel Recipe)
        {
            applicationDbContext.Recipes.Add(Recipe);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recipe = applicationDbContext.Recipes.FirstOrDefault(r => r.Id == id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(RecipeDataModel recipe)
        {
            applicationDbContext.Recipes.Update(recipe);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var recipe = applicationDbContext.Recipes.FirstOrDefault(r => r.Id == id);
            applicationDbContext.Recipes.Remove(recipe);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Recipes/Details/{id}")]
        public IActionResult Details(int id)
        {
            var recipe = applicationDbContext.Recipes.FirstOrDefault(r => r.Id == id);
            return View(recipe);
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
            

            var newRecipe = applicationDbContext.Recipes.FirstOrDefault();

            if (newRecipe == null)
            {
                newRecipe = new RecipeDataModel()
                {
                    Name = "Butter Chicken",
                    Ingredients = new List<IngredientDataModel>()
                    {
                        new IngredientDataModel()
                        {
                            Name = "butter",
                            Quantity = 100,
                            Unit = IngredientUnitDataModel.Grams
                        },
                        new IngredientDataModel()
                        {
                            Name = "Chicken",
                            Quantity = 1000,
                            Unit = IngredientUnitDataModel.Grams
                        },
                        new IngredientDataModel()
                        {
                            Name = settingName,
                            Quantity = 1000,
                            Unit = IngredientUnitDataModel.TableSpoon
                        }
                    }
                };
                applicationDbContext.Add(newRecipe);
                applicationDbContext.SaveChanges();
            }
            return View(applicationDbContext.Recipes.Include(r => r.Ingredients).FirstOrDefault());
        }
        [Route("Recipes/released/{year}/{month}")]
        public ActionResult ByRelease(int year, int month)
        {
            return Content($"Year: {year} and month: {month}");
        }
    }
}