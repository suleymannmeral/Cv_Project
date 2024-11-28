using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Project Name Can Not Be Empty");
            RuleFor(x => x.Completion).NotEmpty().WithMessage("Completion Value Can Not Be Empty");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Project's Logo Can Not Be Empty");
            RuleFor(x => x.ProjectLink).NotEmpty().WithMessage("Project Link Can Not Be Empty");
        }
    }
}
