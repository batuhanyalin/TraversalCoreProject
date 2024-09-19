using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.LoginDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
	public class LoginValidator:AbstractValidator<LoginDto>
	{
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
        }
    }
}
