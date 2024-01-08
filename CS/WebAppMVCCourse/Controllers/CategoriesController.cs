using Microsoft.AspNetCore.Mvc;
using WebAppMVCCourse.Models;

namespace WebAppMVCCourse.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();

            return View(categories);
        }

        public IActionResult Edit(int? ID)
        {
            var category = CategoriesRepository.GetCategoryByID(ID.HasValue ? ID.Value : 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryID, category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

    }
}
