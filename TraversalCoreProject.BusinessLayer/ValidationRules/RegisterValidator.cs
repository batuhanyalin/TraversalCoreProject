using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.RegisterDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
	public class RegisterValidator:AbstractValidator<RegisterDto>
	{
        public RegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad boş geçilemez").MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Ad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez").MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Soyad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez, başında 0 olmadan ve boşluk bırakmadan yazın.").Length(10).WithMessage("Telefon numarası yalnızca 10 karakter olabilir, başında 0 olmadan ve boşluk bırakmadan yazın. Örn: 535123456");
            RuleFor(x => x.Birtday).NotEmpty().WithMessage("Doğum tarihi bilgisi boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez").MaximumLength(60).WithMessage("E-posta en fazla 60 karakter uzunluğunda olabilir");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Girilen parolalar birbirleriyle uyuşmuyor.");
		}
    }
}
