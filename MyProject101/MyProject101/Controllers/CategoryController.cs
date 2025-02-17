using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyProject101.Controllers {
    public class CategoryController : Controller {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IActionResult Index() {
            var values = categoryManager.GetCategoryListWithProducts();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory() {
            return View();
        }

        [HttpPost]
        public IActionResult AddcCategory(Category model) {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(model);
            if (results.IsValid) {
                categoryManager.TInsert(model);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors) {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }
        public IActionResult DeleteCategory(int id) {
            var value = categoryManager.TGetById(id);
            if (value != null) {
                categoryManager.TDelete(value);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditCategory(int id) {
            var value = categoryManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditCategory(Category model){
            categoryManager.TUpdate(model);
            return RedirectToAction("Index");

        }

    }
}
