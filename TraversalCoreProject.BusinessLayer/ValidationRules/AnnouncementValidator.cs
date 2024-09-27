using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AnnouncementDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementCreateDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez").MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır").MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez").MinimumLength(5).WithMessage("İçerik en az 5 karakter olmalıdır").MaximumLength(500).WithMessage("İçerik en fazla 500 karakter olabilir");
        }
    }
}
