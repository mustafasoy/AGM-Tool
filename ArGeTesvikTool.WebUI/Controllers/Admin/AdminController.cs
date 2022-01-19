using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Admin;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{

    [Authorize]
    public class AdminController : BaseController
    {
        public AdminController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {

        }

        public IActionResult List()
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
                AppIdentityRole role = roleViewModel.Adapt<AppIdentityRole>();
                //AppIdentityRole role = new()
                //{
                //    Name = roleViewModel.RoleName,
                //};

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }

                AddModelError(result);
            }

            return View(roleViewModel);
        }
    }
}
