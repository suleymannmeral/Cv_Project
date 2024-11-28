using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Experience Name Can Not Be Empty");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date Can Not Be Empty");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Experience Can Not Be Empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Can Not Be Empty");
            RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Job Title Can Not Be Empty");
        }

    }
}
