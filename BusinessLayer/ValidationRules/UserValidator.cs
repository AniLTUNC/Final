using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName kısmı boş geçilemez!!!");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Lütfen en az 4 karakter giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password alanı boş geçilemez!!!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Lütfen en az 6 karakter giriniz");


        }
    }
}
