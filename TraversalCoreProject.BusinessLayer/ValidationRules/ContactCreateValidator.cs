using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.DefaultDtos.ContactDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class ContactCreateValidator:AbstractValidator<ContactCreateDto>
    {
        public ContactCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez").MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Ad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez").MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Soyad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez").MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır.").MaximumLength(100).WithMessage("Soyad en fazla 100 karakter olabilir.");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Metin boş geçilemez").MinimumLength(3).WithMessage("Metin en az 3 karakter olmalıdır.").MaximumLength(500).WithMessage("Soyad en fazla 500 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez, başında 0 olmadan ve boşluk bırakmadan yazın.").Length(10).WithMessage("Telefon numarası yalnızca 10 karakter olabilir, başında 0 olmadan ve boşluk bırakmadan yazın. Örn: 535123456");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez").MaximumLength(60).WithMessage("E-posta en fazla 60 karakter uzunluğunda olabilir");
        }
    }
}
