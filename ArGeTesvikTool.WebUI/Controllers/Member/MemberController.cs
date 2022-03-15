using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Member;
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

            EditViewModel editViewModel = new()
            {
                User = userInfo
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel userInfoChangeViewModel)
        {
            if (CheckUserInfo(userInfoChangeViewModel.User))
            {
                var validate = ValidatorTool.Validate(new UserInfoChangeValidator(), userInfoChangeViewModel.User);
                if (validate.IsValid)
                {
                    var user = GetCurrentUser;

                    user.Name = userInfoChangeViewModel.User.Name;
                    user.LastName = userInfoChangeViewModel.User.LastName;
                    user.Email = userInfoChangeViewModel.User.Email;

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

                        AddSuccessMessage("Kullanıcı bilgileri güncellendi.");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(userInfoChangeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(EditViewModel passwordInfoChangeViewModel)
        {
            var currentUser = GetCurrentUser;
            var user = await _userManager.FindByIdAsync(currentUser.Id);

            var validate = ValidatorTool.Validate(new PasswordChangeValidator(), passwordInfoChangeViewModel.Password);
            if (validate.IsValid)
            {
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, passwordInfoChangeViewModel.Password.OldPassword, passwordInfoChangeViewModel.Password.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, true);

                        AddSuccessMessage("Kullanıcı şifre bilgileri güncellendi.");
                        return RedirectToAction("Index", "Home");
                    }

                    passwordInfoChangeViewModel.User = user.Adapt<UserDto>();
                    foreach (var item in result.Errors)
                    {
                        if (item.Description.Contains("Eski"))
                        {
                            ModelState.AddModelError("Password.OldPassword", item.Description);
                        }
                        else
                        {
                            ModelState.AddModelError("Password.NewPassword", item.Description);
                        }
                    }
                }
            }

            if (validate.Errors.Count > 0)
            {
                passwordInfoChangeViewModel.User = user.Adapt<UserDto>();
                foreach (var item in validate.Errors)
                {
                    if (item.ErrorMessage.Contains("Eski"))
                    {
                        ModelState.AddModelError("Password.OldPassword", item.ErrorMessage);
                    }

                    if (item.ErrorMessage.Contains("Yeni"))
                    {
                        ModelState.AddModelError("Password.NewPassword", item.ErrorMessage);
                    }

                    if (item.ErrorMessage.Contains("Tekrar"))
                    {
                        ModelState.AddModelError("Password.ConfirmPassword", item.ErrorMessage);
                    }
                }
            }
            return View(passwordInfoChangeViewModel);
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
