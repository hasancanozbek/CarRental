
using Entities.DTOs;
using FluentValidation;

namespace Businnes.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress().MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.Password).MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.Telephone).Length(10).NotEmpty().NotNull();

            RuleFor(c => c.FirstName).MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.LastName).MaximumLength(45).NotEmpty().NotNull();

            RuleFor(c => c.NationalId).Length(11).NotEmpty().NotNull();

            RuleFor(c => c.Address).MaximumLength(255).NotEmpty().NotNull();
        }
    }
}
