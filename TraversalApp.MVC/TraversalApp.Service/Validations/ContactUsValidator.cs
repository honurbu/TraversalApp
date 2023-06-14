using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs.ContactDTO;

namespace TraversalApp.Service.Validations
{
    public class ContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public ContactUsValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x=>x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez");
            RuleFor(x=>x.Content).MinimumLength(10).WithMessage("Minimum 10 karakter giriniz");
            RuleFor(x=>x.Content).MaximumLength(150).WithMessage("Maksimum 150 karakter giriniz");
        }
    }
}
