using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBDEcommerceapp.Models;
using SBDEcommerceapp.Models.ViewModels;

namespace SBDEcommerceapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET Register
        public IActionResult Register()
        {
            return View();
        }

        // POST Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    FullName = model.FullName,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(
                    user,
                    model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction(
                        "Index",
                        "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // GET Login
        public IActionResult Login()
        {
            return View();
        }

        // POST Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    return RedirectToAction(
                        "Index",
                        "Home");
                }

                ModelState.AddModelError(
                    "",
                    "Invalid login attempt");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(
                "Index",
                "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}