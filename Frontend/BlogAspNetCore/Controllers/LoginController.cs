using BlogAspNetCore.Dtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace BlogAspNetCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Token");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult Logout()
        {

            _signInManager.SignOutAsync();
            HttpContext.Session.SetString("JwtToken", "");
            return RedirectToAction("Index", "Home");
        }
    }
}
