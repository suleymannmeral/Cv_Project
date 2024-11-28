using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EducationValidator:AbstractValidator<Education>
    {
        public EducationValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Can Not Be Empty");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Can Not Be Empty");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date Can Not Be Empty");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Education Logo Can Not Be Empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Can Not Be Empty");

        }

    }
}
