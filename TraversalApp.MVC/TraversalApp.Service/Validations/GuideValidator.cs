using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Service.Validations
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş GEÇEMEZ !");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber Tanıtma Alanı Boş GEÇEMEZ !");
        }
    }
}
