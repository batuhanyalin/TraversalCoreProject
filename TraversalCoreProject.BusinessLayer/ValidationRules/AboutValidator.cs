using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.").MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisi giriniz.").MaximumLength(1500).WithMessage("Açıklama en fazla 1500 karakter uzunluğunda olabilir.");
            RuleFor(x=>x.ImageUrl1).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Büyük başlık boş geçilemez").MinimumLength(5).WithMessage("Büyük başlık en az 5 karakter olmak zorundadır.").MaximumLength(100).WithMessage("Büyük başlık en fazla 100 karakter uzunluğunda olabilir.");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Başlık boş geçilemez").MinimumLength(5).WithMessage("Başlık en az 5 karakter olmak zorundadır.").MaximumLength(100).WithMessage("Başlık en fazla 100 karakter uzunluğunda olabilir.");
        }
    }
}
