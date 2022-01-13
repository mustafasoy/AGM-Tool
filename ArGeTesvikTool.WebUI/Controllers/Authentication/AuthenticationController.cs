using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Authentication;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginViewModel)
        {
            var validate = ValidatorTool.Validate(new LoginValidator(), loginViewModel);
            if (validate.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    //if user is exist. clear user cookie info
                    await _signInManager.SignOutAsync();

                    var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Mail adresi veya şifresi bulunamadı!");

            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerViewModel)
        {
            var validate = ValidatorTool.Validate(new RegisterValidator(), registerViewModel);
            //password Msoy001_
            if (validate.IsValid)
            {
                AppIdentityUser identityUser = registerViewModel.Adapt<AppIdentityUser>();

                var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            if (validate.Errors.Count > 0)
            {
                foreach (var error in validate.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }

            return View(registerViewModel);
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().Wait();
        }
    }
}
