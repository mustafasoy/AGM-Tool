using ArGeTesvikTool.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.ValidationRules.CustomValidation
{
    public class PasswordValidator : IPasswordValidator<AppIdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppIdentityUser> manager, AppIdentityUser user, string password)
        {
            List<IdentityError> identityError = new List<IdentityError>();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                identityError.Add(new IdentityError()
                {
                    Code = "PasswordContainsUserName",
                    Description = "Şifre kullanıcı adı içermemeli!"
                });
            }

            if (identityError.Count > 0)
            {
                return Task.FromResult(IdentityResult.Failed(identityError.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
