using AspDotNetCoreSecurity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Error");

            var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
                return View("RegistrationConfirmation");

            foreach (var error in result.Errors)
                ModelState.AddModelError("error", error.Description);
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model,string returnurl=null)
        {
            ViewData["ReturnUrl"] = returnurl;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnurl);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return View(model);
            }
            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return View("LoggedOut");
        }
        private IActionResult RedirectToLocal(string returnurl)
        {
            if (Url.IsLocalUrl(returnurl))
            {
                return Redirect(returnurl);
            }
            return RedirectToAction("Index", "Conference");
        }
    }
}
