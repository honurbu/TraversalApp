using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Service.Validations
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklama Kısmını Boş Geçemezsiniz !'"); 
            RuleFor(a => a.Description).MinimumLength(20).WithMessage("En az 20 karakter girin !'"); 
            RuleFor(a => a.Description).MaximumLength(1000).WithMessage("En çok 1000 karakter girin !'"); 

            RuleFor(a => a.Image).NotEmpty().WithMessage("Resim Kısmını Boş Geçemezsiniz !'"); 
        }
    }
}
