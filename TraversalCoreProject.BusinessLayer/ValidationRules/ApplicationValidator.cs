using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.RegisterDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class ApplicationValidator:AbstractValidator<ApplicationDto>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında boş geçilemez").MinimumLength(3).WithMessage("Hakkında en az 3 karakter olmalıdır.").MaximumLength(1000).WithMessage("Hakkında en fazla 1000 karakter olabilir.");

            RuleFor(x => x.OtherLanguage).MinimumLength(3).WithMessage("Diğer diller en az 3 karakter olmalıdır.").MaximumLength(100).WithMessage("Diğer diller en fazla 100 karakter olabilir.");

            RuleFor(x => x.MainLanguage).NotEmpty().WithMessage("Ana dil boş geçilemez").MinimumLength(3).WithMessage("Ana dil en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Ana dil en fazla 20 karakter olabilir.");

            RuleFor(x => x.HomeTown).NotEmpty().WithMessage("Doğum yeri boş geçilemez").MinimumLength(3).WithMessage("Doğum yeri en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Doğum yeri en fazla 20 karakter olabilir.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez").MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Ad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez").MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Soyad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez, başında 0 olmadan ve boşluk bırakmadan yazın.").Length(10).WithMessage("Telefon numarası yalnızca 10 karakter olabilir, başında 0 olmadan ve boşluk bırakmadan yazın. Örn: 535123456");
            RuleFor(x => x.Birtday).NotEmpty().WithMessage("Doğum tarihi bilgisi boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez").MaximumLength(60).WithMessage("E-posta en fazla 60 karakter uzunluğunda olabilir");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez").MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter olmalıdır.").MaximumLength(16).WithMessage("Kullanıcı adı en fazla 16 karakter olabilir");
        }
    }
}
