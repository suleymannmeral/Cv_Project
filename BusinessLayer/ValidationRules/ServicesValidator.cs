using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServicesValidator:AbstractValidator<Service>
    {
        public ServicesValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Can Not Be Empty");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Icon Can Not Be Empty");

        }
    }
}
