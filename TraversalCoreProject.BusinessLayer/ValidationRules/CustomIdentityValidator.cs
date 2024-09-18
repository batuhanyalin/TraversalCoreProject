using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError() //Bu metodu istediğimiz şekilde döndürmek için yazıyoruz.
            {
                Code = "PasswordRequiresLower", //Hata keyi
                Description = "Lütfen en az 1 tane küçük harf girişi yapınız ('a'-'z')."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük harf girişi yapınız ('A'-'Z')."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Lütfen en az 6 karakter veri girişi yapınız."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az 1 tane sembol girişi yapınız."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $" {userName} kullanıcısı sisteme zaten kayıtlı."
            };
        }
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = "Girilen kullanıc adı geçersizdir."
            };
        }
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError()
            {
                Code = "UserAlreadyHasPassword",
                Description = "Bu kullanıcı zaten bir şifreye sahiptir."
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = $" {email} e-posta adresi sisteme zaten kayıtlı."
            };
        }
    }
}
