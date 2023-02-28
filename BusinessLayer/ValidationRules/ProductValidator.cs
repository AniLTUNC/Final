using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Lütfen En Az İki Karakter Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Lütfen En Az Beş Karakter Giriniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
        }
    }
}
