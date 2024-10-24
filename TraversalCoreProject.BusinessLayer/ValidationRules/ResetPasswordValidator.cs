using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.DefaultDtos.PasswordDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class ResetPasswordValidator:AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez.").MinimumLength(6).WithMessage("Parola minimum 6 karakter olmak zorundadır.").MaximumLength(12).WithMessage("Parola maksimum 12 karakter olabilir.");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Parola tekrarı boş bırakılamaz.").Equal(x=>x.Password).WithMessage("Parola tekrarıyla parola aynı olmalıdır.");
        }
    }
}
