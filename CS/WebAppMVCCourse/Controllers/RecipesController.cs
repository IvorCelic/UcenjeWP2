using Microsoft.AspNetCore.Mvc;
using WebAppMVCCourse.Models;

namespace WebAppMVCCourse.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            var recipes = RecipesRepository.GetRecipes();

            return View(recipes);
        }

        public IActionResult Edit(int? ID)
        {
            ViewBag.Action = "edit";

            var recipe = RecipesRepository.GetRecipeByID(ID.HasValue ? ID.Value : 0);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                RecipesRepository.UpdateRecipe(recipe.RecipeID, recipe);

                return RedirectToAction(nameof(Index));
            }

            return View(recipe);
        }
    }
}
