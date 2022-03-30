using ArGeTesvikTool.Core.Entities;
using ArGeTesvikTool.WebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ArGeTesvikTool.WebUI.Controllers.Authentication
{
    public class BaseController : Controller
    {
        protected UserManager<AppIdentityUser> _userManager;
        protected RoleManager<AppIdentityRole> _roleManager;
        protected SignInManager<AppIdentityUser> _signInManager;

        protected AppIdentityUser GetCurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;

        public BaseController()
        {

        }

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

        public bool CheckValidatorError(ValidationResult validate)
        {
            return validate.Errors.Count > 0;
        }

        public void AddSuccessMessage(string message)
        {
            TempData["SuccessMessage"] = message;
        }

        public FileStreamResult DownloadFile(IFileEntity entity)
        {
            var content = new MemoryStream(entity.Content);
            var contentType = entity.ContentType;
            var fileName = entity.FileName;

            return File(content, contentType, fileName);
        }

        public static bool VerifyIdentityNumber(string identityNumber)
        {
            if (identityNumber.Length == 11)
            {
                long atcNumber, btcNumber, identityNo;
                long c1, c2, c3, c4, c5, c6, c7, c8, c9, q1, q2;

                identityNo = long.Parse(identityNumber);

                atcNumber = identityNo / 100;
                btcNumber = identityNo / 100;

                c1 = atcNumber % 10; 
                atcNumber /= 10;
                
                c2 = atcNumber % 10; 
                atcNumber /= 10;
                
                c3 = atcNumber % 10; 
                atcNumber /= 10;
                
                c4 = atcNumber % 10; 
                atcNumber /= 10;
                
                c5 = atcNumber % 10; 
                atcNumber /= 10;
                
                c6 = atcNumber % 10; 
                atcNumber /= 10;
                
                c7 = atcNumber % 10; 
                atcNumber /= 10;
                
                c8 = atcNumber % 10; 
                atcNumber /= 10;
                
                c9 = atcNumber % 10;
                
                q1 = ((10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10);
                q2 = ((10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10);

                return((btcNumber * 100) + (q1 * 10) + q2 == identityNo);
            }

            return false;
        }
    }
}
