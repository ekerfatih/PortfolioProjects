using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject101.Models;
using System.Threading.Tasks;

namespace MyProject101.Controllers {
    public class SettingsController : Controller {

        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager) {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();

            userEditViewModel.Name = values.Name;
            userEditViewModel.SurName = values.Surname;
            userEditViewModel.Gender = values.Gender;
            userEditViewModel.Email = values.Email;
            


            return View(userEditViewModel);
        }
    }
}