
using Entities.DTOs;
using FluentValidation;

namespace Businnes.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarAddDto>
    {
        public CarValidator()
        {
            RuleFor(c => c.Price).GreaterThan(0);

            RuleFor(c => c.ModelYear).ExclusiveBetween(1900,2024);

            RuleFor(c => c.ColourId).GreaterThan(0);
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.GearTypeId).GreaterThan(0);
            RuleFor(c => c.FuelTypeId).GreaterThan(0);

            RuleFor(c => c.Model).NotNull().NotEmpty();
        }
    }
}
