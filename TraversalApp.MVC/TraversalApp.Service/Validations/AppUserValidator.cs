using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;

namespace TraversalApp.Service.Validations
{
    public class AppUserValidator : AbstractValidator<AppUserDto>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adınızı Giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyadınızı Giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen EMail Adresinizi Giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifrelerinz uyumlu olmalıdır"); ;
   
        }
    }
}
