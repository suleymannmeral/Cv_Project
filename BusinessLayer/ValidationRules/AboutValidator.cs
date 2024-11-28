using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Can Not Be Empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Can Not Be Empty");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age Can Not Be Empty");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Can Not Be Empty");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone Can Not Be Empty");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adress Can Not Be Empty");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Can Not Be Empty");

        }
    }
}
