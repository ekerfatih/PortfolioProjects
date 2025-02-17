using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation {
    public class CustomerValidator : AbstractValidator<Customer> {
        public CustomerValidator() {
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir bilgisi boş geçilemez");
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("İsim boş geçilemez");
        }
    }
}
