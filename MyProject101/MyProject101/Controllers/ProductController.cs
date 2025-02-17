using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyProject101.Controllers {
    public class ProductController : Controller {

        ProductManager productManager = new ProductManager(new EfProductDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index() {
            var values = productManager.GetProductsWithCategories();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct() {
            List<SelectListItem> values = (from x in categoryManager.TGetList()
                                           select new SelectListItem {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product model) {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(model);
            if (results.IsValid) {
                productManager.TInsert(model);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors) {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            List<SelectListItem> values = (from x in categoryManager.TGetList()
                                           select new SelectListItem {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(model);
        }
        public IActionResult DeleteProduct(int id) {
            var value = productManager.TGetById(id);
            if (value != null) {
                productManager.TDelete(value);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditProduct(int id) {
            List<SelectListItem> values = (from x in categoryManager.TGetList()
                                           select new SelectListItem {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = productManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditProduct(Product model) {
            List<SelectListItem> values = (from x in categoryManager.TGetList()
                                           select new SelectListItem {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            productManager.TUpdate(model);
            return RedirectToAction("Index");

        }

    }
}
