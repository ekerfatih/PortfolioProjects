using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation {
    public class ProductValidator : AbstractValidator<Product>{
        public ProductValidator() {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz");
            RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok sayısı boş geçilemez");
            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Fiyat boş geçilemez");
        }
    }
}
