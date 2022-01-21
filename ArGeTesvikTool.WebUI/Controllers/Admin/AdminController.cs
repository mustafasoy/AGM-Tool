using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Admin;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{

    //[Authorize]
    public class AdminController : BaseController
    {
        public AdminController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {

        }

        public IActionResult ListUser()
        {
            var userList = _userManager.Users.ToList();
            List<UserDto> newUser = new();

            foreach (var item in userList)
            {
                UserDto userLine = item.Adapt<UserDto>();
                newUser.Add(userLine);
            }

            UserListViewModel userListViewModel = new()
            {
                UserList = newUser
            };

            return View(userListViewModel);
        }


        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleDto roleViewModel)
        {
            var validate = ValidatorTool.Validate(new RoleCreateValidator(), roleViewModel);
            if (validate.IsValid)
            {
                AppIdentityRole role = new()
                {
                    Name = roleViewModel.Name,
                    RoleText = roleViewModel.RoleText
                };

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }

                AddModelError(result);
            }

            if (CheckValidatorError(validate))
                AddValidatorError(validate);


            return View(roleViewModel);
        }

        public IActionResult ListRole()
        {
            var roleList = _roleManager.Roles.ToList();

            List<RoleDto> listRole = new();

            foreach (var item in roleList)
            {
                RoleDto roleLine = item.Adapt<RoleDto>();
                listRole.Add(roleLine);
            }

            RoleListViewModel roleListViewModel = new()
            {
                RoleList = listRole
            };

            return View(roleListViewModel);
        }

        public IActionResult RoleDelete(string id)
        {
            RoleDto roleInfo = GetRole(id);

            return View(roleInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleDelete(RoleDto roleViewModel)
        {
            var validate = ValidatorTool.Validate(new RoleCreateValidator(), roleViewModel);
            if (validate.IsValid)
            {
                var identityRole = await _roleManager.FindByIdAsync(roleViewModel.Id);
                if (identityRole != null)
                {
                    var result = await _roleManager.DeleteAsync(identityRole);
                    if (result.Succeeded)
                        return RedirectToAction("ListRole");
                }
            }

            if (CheckValidatorError(validate))
                AddValidatorError(validate);

            return View(roleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleUpdate(RoleDto roleViewModel)
        {
            var validate = ValidatorTool.Validate(new RoleCreateValidator(), roleViewModel);
            if (validate.IsValid)
            {
                var identityRole = await _roleManager.FindByIdAsync(roleViewModel.Id);
                if (identityRole != null)
                {
                    identityRole.Name = roleViewModel.Name;
                    identityRole.RoleText = roleViewModel.RoleText;

                    var result = await _roleManager.UpdateAsync(identityRole);
                    if (result.Succeeded)
                        return RedirectToAction("ListRole");
                }
            }

            if (CheckValidatorError(validate))
                AddValidatorError(validate);

            return View(roleViewModel);
        }

        public IActionResult RoleAssign(string id)
        {
            TempData["UserId"] = id;
            AppIdentityUser identityUser = _userManager.FindByIdAsync(id).Result;
            ViewBag.userName = identityUser.UserName;

            IQueryable<AppIdentityRole> identityRole = _roleManager.Roles;
            List<string> userRoles = _userManager.GetRolesAsync(identityUser).Result as List<string>;
            List<RoleAssignViewModel> roleAssignViewModels = new();

            foreach (var item in identityRole)
            {
                RoleAssignViewModel roleAssign = item.Adapt<RoleAssignViewModel>();

                roleAssign.Exist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(roleAssign);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> roleAssignViewModels)
        {
            AppIdentityUser identityUser = _userManager.FindByIdAsync(TempData["UserId"].ToString()).Result;

            foreach (var item in roleAssignViewModels)
            {
                //if (item.Exist)
                //    _userManager.AddToRoleAsync(identityUser, item.Name);
                
                //if (!item.Exist)
                //    _userManager.RemoveFromRoleAsync(identityUser, item.Name);
            }

            return View(roleAssignViewModels);
        }

        private RoleDto GetRole(string id)
        {
            var getRole = _roleManager.FindByIdAsync(id).Result;

            RoleDto roleInfo = getRole.Adapt<RoleDto>();

            return roleInfo;
        }

        private static bool CheckValidatorError(ValidationResult validate)
        {
            return validate.Errors.Count > 0;
        }
    }
}
