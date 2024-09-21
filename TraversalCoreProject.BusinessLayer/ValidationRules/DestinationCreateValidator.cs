﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.ValidationRules
{
    public class DestinationCreateValidator:AbstractValidator<DestinationCreateDto>
    {
        public DestinationCreateValidator()
        {
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş geçilemez.");
            RuleFor(x=>x.DayNight).NotEmpty().WithMessage("Gün bilgisi boş geçilemez.");
            RuleFor(x=>x.Text1).NotEmpty().WithMessage("Metin bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Metin bilgisi en az 3 karakter olmalıdır.").MaximumLength(2000).WithMessage("Metin bilgisi en fazla 2000 karakter olabilir.");
            RuleFor(x=>x.StartDate).NotEmpty().WithMessage("Tarih bilgisi boş geçilemez.");
            RuleFor(x=>x.Capacity).NotEmpty().WithMessage("Kapasite bilgisi boş geçilemez.");
            RuleFor(x=>x.City).NotEmpty().WithMessage("Şehir bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Şehir bilgisi en az 3 karakter olmalıdır.").MaximumLength(50).WithMessage("Şehir bilgisi en fazla 50 karakter olabilir.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Ülke bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Ülke bilgisi en az 3 karakter olmalıdır.").MaximumLength(50).WithMessage("Ülke bilgisi en fazla 50 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş geçilemez.").MinimumLength(3).WithMessage("Açıklama bilgisi en az 3 karakter olmalıdır.").MaximumLength(1000).WithMessage("Açıklama bilgisi en fazla 1000 karakter olabilir.");
        }
    }
}