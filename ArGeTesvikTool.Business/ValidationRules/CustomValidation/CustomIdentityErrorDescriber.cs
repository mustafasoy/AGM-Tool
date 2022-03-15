using Microsoft.AspNetCore.Identity;

namespace ArGeTesvikTool.Business.ValidationRules.CustomValidation
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        #region UserName
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError() { Code = "InvalidUserName", Description = $"Bu {userName} geçersizdir." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = "DuplicateUserName", Description = $"{userName} kullanıcı adı kullanılmaktadır." };
        }
        #endregion

        #region Email
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = "DuplicateEmail", Description = $"{email} mail adresi kullanılmaktadır." };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError() { Code = "InvalidToken", Description = "Şifre yenileme linkin süresi dolmuştur." };
        }
        #endregion

        #region Password
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = "PasswordTooShort", Description = $"Şifreniz en az {length} karakterli olmadılır." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError() { Code = "PasswordMismatch", Description = "Eski şifreniz hatalı." };
        }
        #endregion
    }
}
