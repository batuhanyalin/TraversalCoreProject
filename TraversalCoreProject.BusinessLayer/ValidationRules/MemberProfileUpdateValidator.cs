using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class MemberProfileUpdateValidator : AbstractValidator<MyProfileUpdateDto>
    {
        public MemberProfileUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez").MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Ad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez").MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır.").MaximumLength(20).WithMessage("Soyad en fazla 20 karakter olabilir.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş geçilemez, başında 0 olmadan ve boşluk bırakmadan yazın.").Length(10).WithMessage("Telefon numarası yalnızca 10 karakter olabilir, başında 0 olmadan ve boşluk bırakmadan yazın. Örn: 535123456");
            RuleFor(x => x.Birtday).NotEmpty().WithMessage("Doğum tarihi bilgisi boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez").MaximumLength(60).WithMessage("E-posta en fazla 60 karakter uzunluğunda olabilir");
            RuleFor(x => x.Profession).MinimumLength(3).WithMessage("Meslek en az 3 karakter olmalıdır.").MaximumLength(16).WithMessage("Meslek en fazla 16 karakter olabilir");
            RuleFor(x => x.MainLanguage).MinimumLength(3).WithMessage("Ana dil en az 3 karakter olmalıdır.").MaximumLength(16).WithMessage("Ana dil en fazla 16 karakter olabilir");
            RuleFor(x => x.OtherLanguage).MinimumLength(3).WithMessage("Diğer diller en az 3 karakter olmalıdır.").MaximumLength(100).WithMessage("Diğer diller en fazla 100 karakter olabilir");
            RuleFor(x => x.HomeTown).MinimumLength(3).WithMessage("Doğum Yeri en az 3 karakter olmalıdır.").MaximumLength(16).WithMessage("Doğum Yeri en fazla 50 karakter olabilir");
            RuleFor(x => x.InstagramUrl).MinimumLength(23).WithMessage("Instagram URL en az 23 karakter olmalıdır. Örn: https://www.instagram.com/kullaniciAdi").MaximumLength(100).WithMessage("Instagram URL en fazla 100 karakter olabilir");
            RuleFor(x => x.TwitterUrl).MinimumLength(15).WithMessage("Twitter URL en az 15 karakter olmalıdır. Örn: https://www.x.com/kullaniciAdi").MaximumLength(100).WithMessage("Twitter URL en fazla 100 karakter olabilir");
        }
    }
}
