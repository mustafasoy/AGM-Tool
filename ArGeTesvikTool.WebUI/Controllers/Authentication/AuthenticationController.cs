using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Concrete;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Authentication;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class AuthenticationController : BaseController
    {
        readonly IConfiguration _configuration;
        private IMailService _mailService;
        private IWebHostEnvironment _hostingEnvironment;

        public AuthenticationController(IConfiguration configuration, IMailService mailService, IWebHostEnvironment hostingEnvironment, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {
            _configuration = configuration;
            _mailService = mailService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginViewModel)
        {
            var validate = ValidatorTool.Validate(new LoginValidator(), loginViewModel);
            if (validate.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {

                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliğine kitlenmiştir!");
                        return View(loginViewModel);
                    }
                    //if user is exist. clear user cookie info
                    await _signInManager.SignOutAsync();

                    var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);

                    if (signInResult.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);

                        //if user try to enter page without login, after login redirect to that page
                        if (TempData["ReturnUrl"] != null)
                            return Redirect(TempData["ReturnUrl"].ToString());

                        return RedirectToAction("Index", "Home");
                    }

                    //if user enter wrong email or password, user will be locked for 5 mins
                    await UserLock(user);
                }
                else
                    ModelState.AddModelError("", "Bu mail adresine ait kullanıcı bulunamadı!");

            }
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerViewModel)
        {
            var validate = ValidatorTool.Validate(new RegisterValidator(), registerViewModel);

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

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordViewModel)
        {
            var validate = ValidatorTool.Validate(new ResetPasswordValidator(), resetPasswordViewModel);
            if (validate.IsValid)
            {

                var pathToFile = _hostingEnvironment.WebRootPath
                                + Path.DirectorySeparatorChar.ToString()
                                + "mail-templates"
                                + Path.DirectorySeparatorChar.ToString()
                                + "ResetPasswordEmail.html";

                string htmlBody;
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    htmlBody = SourceReader.ReadToEnd();
                }

                var mailConfiguration = new MailConfigurationDto
                {
                    SmtpServer = _configuration.GetValue<string>("EmailConfiguration:SmtpServer"),
                    Port = _configuration.GetValue<int>("EmailConfiguration:Port"),
                    From = _configuration.GetValue<string>("EmailConfiguration:From"),
                    UserName = _configuration.GetValue<string>("EmailConfiguration:Username"),
                    Password = _configuration.GetValue<string>("EmailConfiguration:Password"),
                };

                _mailService.CreateMail(mailConfiguration, "saasds", "sadsad");

                var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

                if (user != null)
                {
                    string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    string passwordResetUrl = Url.Action("ResetPasswordConfirm", "Authentication", new
                    {
                        userId = user.Id,
                        token = passwordResetToken
                    }
                    , HttpContext.Request.Scheme);

                    _mailService.SendMail();
                    ViewBag.Status = "succes";
                }
                else
                    ModelState.AddModelError("", "Kayıtlı mail adresi bulunamadı!");

            }
            return View(resetPasswordViewModel);
        }

        public IActionResult ResetPasswordConfirm(string userId, string token)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordConfirm([Bind("NewPassword")] ResetPasswordDto resetPasswordViewModel)
        {
            string userId = TempData["UserId"].ToString();
            string token = TempData["Token"].ToString();

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordViewModel.NewPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    return RedirectToAction("Login");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(resetPasswordViewModel);
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().Wait();
        }

        private async Task UserLock(AppIdentityUser user)
        {
            await _userManager.AccessFailedAsync(user);
            int failCounter = await _userManager.GetAccessFailedCountAsync(user);
            if (failCounter == 3)
            {
                await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(5)));
                ModelState.AddModelError("", "Hesabınız 3 başarısız girişten dolayı 5 dakika kitlenmiştir!");
            }
            else
                ModelState.AddModelError("", "Mail adresi veya şifresi yanlış!");
        }
    }
}
