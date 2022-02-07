using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Admin;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
                Users = newUser
            };

            return View(userListViewModel);
        }

        public IActionResult EditUser(string id)
        {
            AppIdentityUser identityUser = _userManager.FindByIdAsync(id).Result;

            IQueryable<AppIdentityRole> identityRole = _roleManager.Roles;
            var getUserRole = _userManager.GetRolesAsync(identityUser).Result.FirstOrDefault();

            TempData["UserRole"] = getUserRole != null
                ? getUserRole
                : string.Empty;

            RoleDto userRole = new()
            {
                Name = getUserRole,
            };

            List<RoleDto> listRole = new() { };
            listRole.Add(userRole);
            foreach (var item in identityRole)
            {
                if (item.Name != getUserRole)
                {
                    RoleDto roleLine = item.Adapt<RoleDto>();
                    listRole.Add(roleLine);
                }
            }

            ViewBag.RoleList = listRole;

            UserViewModel userViewModel = new()
            {
                User = identityUser.Adapt<UserDto>(),
                Roles = listRole
            };

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModel userViewModel)
        {
            var validate = ValidatorTool.Validate(new UserInfoChangeValidator(), userViewModel.User);
            if (validate.IsValid)
            {
                AppIdentityUser identityUser = _userManager.FindByIdAsync(userViewModel.User.Id).Result;

                identityUser.Name = userViewModel.User.Name;
                identityUser.LastName = userViewModel.User.LastName;

                var identityResult = await _userManager.UpdateAsync(identityUser);

                string oldUserRole = TempData["UserRole"].ToString();

                if (oldUserRole != userViewModel.RoleName)
                {
                    if (!string.IsNullOrEmpty(oldUserRole))
                        await _userManager.RemoveFromRoleAsync(identityUser, oldUserRole);

                    await _userManager.AddToRoleAsync(identityUser, userViewModel.RoleName);
                }

                if (!identityResult.Succeeded)
                {
                    AddModelError(identityResult);
                }
                else
                {
                    await _userManager.UpdateSecurityStampAsync(identityUser);
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(identityUser, true);

                    TempData["SuccessMessage"] = "Güncelleme işlemi tamamlandı...";


                    return RedirectToAction("ListUser");
                }
            }
            return View(userViewModel);
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
                    return RedirectToAction("ListUser");
                }

                AddModelError(result);
            }

            if (CheckValidatorError(validate))
                AddValidatorError(validate);


            return View(roleViewModel);
        }

        public IActionResult ListRole()
        {
            List<RoleDto> listRole = GetUserRoleList();

            RoleListViewModel roleListViewModel = new()
            {
                Roles = listRole
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

        private RoleDto GetRole(string id)
        {
            var getRole = _roleManager.FindByIdAsync(id).Result;

            RoleDto roleInfo = getRole.Adapt<RoleDto>();

            return roleInfo;
        }

        private List<RoleDto> GetUserRoleList()
        {
            List<AppIdentityRole> roleList = _roleManager.Roles.ToList();
            List<RoleDto> listRole = new();

            foreach (var item in roleList)
            {
                RoleDto roleLine = item.Adapt<RoleDto>();
                listRole.Add(roleLine);
            }

            return listRole;
        }
    }
}
