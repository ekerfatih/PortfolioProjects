using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyProject101.Controllers {
    public class CustomerController : Controller {

        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        public IActionResult Index() {
            var values = customerManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer() {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer model) {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(model);
            if (results.IsValid) {
                customerManager.TInsert(model);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors) {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }
        public IActionResult DeleteCustomer(int id) {
            var value = customerManager.TGetById(id);
            if (value != null) {
                customerManager.TDelete(value);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditCustomer(int id) {
            var value = customerManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer model) {
            customerManager.TUpdate(model);
            return RedirectToAction("Index");

        }

    }
}
