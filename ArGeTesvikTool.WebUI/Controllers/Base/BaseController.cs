﻿using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class BaseController : Controller
    {
        protected UserManager<AppIdentityUser> _userManager;
        protected RoleManager<AppIdentityRole> _roleManager;
        protected SignInManager<AppIdentityUser> _signInManager;

        protected AppIdentityUser GetCurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        
        public BaseController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public void AddModelError(IdentityResult identityResult)
        {
            foreach (var item in identityResult.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        public void AddValidatorError(ValidationResult validatorError)
        {
            foreach (var item in validatorError.Errors)
            {
                ModelState.AddModelError("", item.ErrorMessage);
            }
        }
    }
}