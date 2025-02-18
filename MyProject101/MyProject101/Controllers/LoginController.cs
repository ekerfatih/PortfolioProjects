using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject101.Models;

namespace MyProject101.Controllers;

public class LoginController : Controller {

    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager) {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserLoginViewModel model) {
        if(ModelState.IsValid){
            var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,true);
            if(result.Succeeded){
                return RedirectToAction("Index","Category");
            }
            ModelState.AddModelError("","Hatalı kullanıcı adı veya şifre girdiniz");
        }
        return View();
    }
}
