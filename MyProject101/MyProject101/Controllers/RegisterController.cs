using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject101.Models;

namespace MyProject101.Controllers {
    public class RegisterController : Controller {


        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model) {
            AppUser appUser = new AppUser() {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email = model.Email
            };

            if (ModelState.IsValid) {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Login");
                }
                foreach (var item in result.Errors) {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(model);
        }
    }
}