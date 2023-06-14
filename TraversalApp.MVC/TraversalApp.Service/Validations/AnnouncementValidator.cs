using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;

namespace TraversalApp.Service.Validations
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru başlığı boş geçilemez !");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içeriği boş geçilemez !");

            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Mesaj başlığı minimum 3 karakter içermelidir");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Mesaj içeriği minimum 10 karakter içermelidir");  
            
            RuleFor(x => x.Title).MaximumLength(25).WithMessage("Mesaj başlığı maksimum 25 karakter içermelidir");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Mesaj başlığı maksimum 500 karakter içermelidir");

        }
    }
}
