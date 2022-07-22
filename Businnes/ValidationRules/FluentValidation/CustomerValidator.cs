
using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress().MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.Telephone).Length(10).NotEmpty().NotNull();

            RuleFor(c => c.FirstName).MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.LastName).MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.NationalId).Length(11).NotEmpty().NotNull();

            RuleFor(c => c.Address).MaximumLength(255).NotEmpty().NotNull();
        }
    }
}
