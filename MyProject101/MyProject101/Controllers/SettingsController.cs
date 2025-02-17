using Microsoft.AspNetCore.Mvc;

namespace MyProject101.Controllers {
    public class SettingsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}