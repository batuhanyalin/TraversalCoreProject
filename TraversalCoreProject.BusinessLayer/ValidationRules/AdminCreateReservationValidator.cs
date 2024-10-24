using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ReservationDtos;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class AdminCreateReservationValidator : AbstractValidator<AdminReservationCreateDto>
    {
        public AdminCreateReservationValidator()
        {
            RuleFor(x => x.PersonCount).GreaterThan(0).WithMessage("Kişi sayısı 0'dan büyük olmalıdır.").WithMessage("Kişi sayısı boş geçilemez.");
        }
    }
}
