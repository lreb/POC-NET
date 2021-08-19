using FluentValidation;
using FluenValidationTesting.Models;

namespace FluenValidationTesting.Validators
{
    public class ValueInputValidator : AbstractValidator<ValueInput>
    {
        public ValueInputValidator() 
        {
            RuleFor(rule => rule.Name).MinimumLength(3).WithMessage("Message should be greater than 3 characters");
            RuleFor(rule => rule.Quantity).GreaterThan(0).WithMessage("Quantity should be greater than 0 characters");
        }
    }
}
