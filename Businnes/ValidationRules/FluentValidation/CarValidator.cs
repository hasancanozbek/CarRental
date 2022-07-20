
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarAddDto>
    {
        public CarValidator()
        {
            RuleFor(c => c.Price).GreaterThan(0).NotNull().NotEmpty();

            RuleFor(c => c.ModelYear).ExclusiveBetween(1900,2024).NotNull().NotEmpty();

            RuleFor(c => c.ColourId).GreaterThan(0).NotNull().NotEmpty();

            RuleFor(c => c.BrandId).GreaterThan(0).NotNull().NotEmpty();

            RuleFor(c => c.GearTypeId).GreaterThan(0).NotNull().NotEmpty();

            RuleFor(c => c.FuelTypeId).GreaterThan(0).NotNull().NotEmpty();

            RuleFor(c => c.Model).NotNull().NotEmpty().MaximumLength(45);

            RuleFor(c => c.Description).MaximumLength(255).NotEmpty();
        }
    }
}
