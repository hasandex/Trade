using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Trade.Repo.Base;

namespace Trade.Controllers
{
    public class Categories : Controller
    {
        private readonly ICategoriesRepo _categoriesRepo;
        public Categories(ICategoriesRepo categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }
        public IActionResult Index()
        {
            return View(_categoriesRepo.GetAll());
        }

        public IActionResult Upsert(int? categoryId)
        {
            if (categoryId == null)
            {
                // Create a new category
                return View();
            }
            else
            {
                // Update an existing category
                var category = _categoriesRepo.GetById((int)categoryId);
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {

                // Create a new category
                if (category.Id == 0)
                {
                    if (_categoriesRepo.GetByName(category.Name) != null)
                    {
                        ModelState.AddModelError("Name", "This category is already exsit!");
                        return View();
                    }
                    _categoriesRepo.Add(category);
                }
                else
                {
                    // Update the existing category
                    _categoriesRepo.Update(category);
                }

                return RedirectToAction("Index", "Categories"); // Redirect to the appropriate view after successful create/update
            }
            //hellosssasdasdas
            return View(category);
        }
    }
}
