using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Concrete;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation;
using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.Mail;
using ArGeTesvikTool.WebUI.Models;
using ArGeTesvikTool.WebUI.Models.Authentication;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AuthenticationController(IConfiguration configuration, IMailService mailService, IWebHostEnvironment hostingEnvironment, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, RoleManager<AppIdentityRole> roleManager = null) : base(userManager, signInManager, roleManager)
        {
            _configuration = configuration;
            _mailService = mailService;
            _hostingEnvironment = hostingEnvironment;
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
                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliğine kitlenmiştir.");
                        return View(loginViewModel);
                    }

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Giriş yapmak için mail adresiniz onaylanmalıdır.");
                        return View(loginViewModel);
                    }
                    //if user is exist. clear user cookie info
                    await _signInManager.SignOutAsync();

                    var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, true);

                    if (signInResult.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Mail adresiniz veya şifreniz yanlış.");
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Bu mail adresine ait kullanıcı bulunamadı.");
                }
            }

            if (validate.Errors.Count > 0)
                AddValidatorError(validate);

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

            bool checkIdentity = VerifyIdentityNumber(registerViewModel.IdentityNumber);
            if (!checkIdentity)
            {
                ModelState.AddModelError("IdentityNumber", "Kimlik numarasını kontrol ediniz.");
                return View(registerViewModel);
            }

            if (validate.IsValid)
            {
                AppIdentityUser identityUser = registerViewModel.Adapt<AppIdentityUser>();

                var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (result.Succeeded)
                {

                    var userConfirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);

                    var userConfirmLink = Url.Action("ConfirmEmail", "Authentication", new
                    {
                        userId = identityUser.Id,
                        token = userConfirmToken
                    },
                    HttpContext.Request.Scheme);


                    //send an email with this link
                    MailMessage message = ConfirmAccountMail(registerViewModel, userConfirmLink);
                    await _mailService.SendMailAsync(message);

                    return RedirectToAction("ConfirmEmail");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            if (validate.Errors.Count > 0)
                AddValidatorError(validate);

            return View(registerViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userManager.FindByIdAsync(userId);

                IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Mail adresi onaylanmıştır. Giriş yapabilirsiniz.";
                    return RedirectToAction("Login");
                }

                ViewBag.EmailConfirm = "Mail adresi onaylanamamıştır.";
            }

            ViewBag.EmailConfirm = "Kullanıcı hesabınız onaya gönderilmiştir.";

            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Şifre değiştirmek için mail adresiniz onaylanmalıdır.");
                return View(resetPasswordViewModel);
            }

            if (user != null)
            {
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                string passwordResetUrl = Url.Action("ResetPasswordConfirm", "Authentication", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                },
                HttpContext.Request.Scheme);

                //send an email with this link
                MailMessage message = ChangePasswordMail(resetPasswordViewModel, passwordResetUrl);
                await _mailService.SendMailAsync(message);

                TempData["ConfirmPassword"] = "Şifrenizi sıfırlamak için mail adresinizi kontrol edin.";
                return RedirectToAction("ConfirmPassword");
            }

            ModelState.AddModelError("", "Kayıtlı mail adresi bulunamadı.");

            return View(resetPasswordViewModel);
        }

        public IActionResult ResetPasswordConfirm(string userId, string token)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordDto resetPasswordViewModel)
        {
            var validate = ValidatorTool.Validate(new ResetPasswordValidator(), resetPasswordViewModel);
            if (validate.IsValid)
            {
                var user = await _userManager.FindByIdAsync(resetPasswordViewModel.UserId);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);

                        AddSuccessMessage("Şifreniz sıfırlandı. Giriş yapabilirsiniz");
                        return RedirectToAction("Login");
                    }

                    AddModelError(result);
                }
            }

            if (validate.Errors.Count > 0)
                AddValidatorError(validate);

            return View(resetPasswordViewModel);
        }

        public IActionResult ConfirmPassword()
        {
            return View();
        }

        public void Logout()
        {
            _signInManager.SignOutAsync().Wait();
        }

        private MailMessage ConfirmAccountMail(RegisterDto user, string userConfirmLink)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "mail-templates", "ConfirmAccount.html");

            string subject = "Yeni personel hesabını onaylayın";
            string fullName = string.Format("{0} {1}", user.Name, user.LastName);
            string buttonText = "Şimdi aktifleştir";

            var builder = new BodyBuilder();
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                builder.HtmlBody = reader.ReadToEnd();
            }
            string htmlBody = builder.HtmlBody.ToString();

            //{0}: subject
            //{1}: email
            //{2}: username
            //{3}: user fullname
            //{4}: callbackURL
            //{5}: button text
            string messageBody = string.Format(
                htmlBody,
                subject,
                user.Email,
                user.Name,
                fullName,
                userConfirmLink,
                buttonText
                );

            MailMessage message = new(
                new string[] {
                    user.Email
                },
                subject,
                messageBody);

            return message;
        }

        private MailMessage ChangePasswordMail(ResetPasswordDto user, string passwordResetUrl)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "mail-templates", "ChangePassword.html");

            string subject = "Parolanız sıfırla";
            string buttonText = "Şimdi değiştirin";

            var builder = new BodyBuilder();
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                builder.HtmlBody = reader.ReadToEnd();
            }
            string htmlBody = builder.HtmlBody;

            //{0}: subject
            //{1}: email
            //{2}: callbackURL
            //{3}: button text
            string messageBody = string.Format(
                htmlBody,
                subject,
                user.Email,
                passwordResetUrl,
                buttonText
                );

            MailMessage message = new(
                new string[] {
                    user.Email
                },
                subject,
                messageBody);

            return message;
        }
    }
}
