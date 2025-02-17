using Microsoft.AspNetCore.Mvc;

namespace MyProject101.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
