using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Member
{
    [Authorize]
    public class MemberController : BaseController
    {
        public MemberController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            var user = GetCurrentUser;
            UserDto userInfo = user.Adapt<UserDto>();

            return View(userInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDto userInfoChangeViewModel)
        {
            if (CheckUserInfo(userInfoChangeViewModel))
            {
                var validate = ValidatorTool.Validate(new UserInfoChangeValidator(), userInfoChangeViewModel);
                if (validate.IsValid)
                {
                    var user = GetCurrentUser;

                    user.Name = userInfoChangeViewModel.Name;
                    user.LastName = userInfoChangeViewModel.LastName;
                    user.Email = userInfoChangeViewModel.Email;

                    var identityResult = await _userManager.UpdateAsync(user);
                    if (!identityResult.Succeeded)
                    {
                        AddModelError(identityResult);
                    }
                    else
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, true);

                        ViewBag.success = "true";
                    }
                }
            }

            return View(userInfoChangeViewModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private static bool CheckUserInfo(UserDto user)
        {
            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Email))
                return true;
            else
                return false;
        }
    }
}
