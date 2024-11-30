using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator:AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Can Not Be Empty");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value Can Not Be Empty");
            RuleFor(x => x.imageUrl).NotEmpty().WithMessage("ImageUrl Can Not Be Empty");

        }
    }
}
