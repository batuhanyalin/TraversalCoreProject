using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class MemberNewReservationValidator : AbstractValidator<MemberNewReservationDto>
    {
        public MemberNewReservationValidator()
        {
            RuleFor(x => x.PersonCount).GreaterThan(0).WithMessage("Kişi sayısı 0'dan büyük olmalıdır.").WithMessage("Kişi sayısı boş geçilemez.");
        }

        //RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez.").Must(BeAValidInteger).WithMessage("Lütfen yalnızca sayı girin.").MaximumLength(2).WithMessage("Kişi sayısı en fazla 2 basamaklı olabilir.");

        //private bool BeAValidInteger(string personCount)
        //{
        //    return int.TryParse(personCount, out _);
        //}
    }
}
