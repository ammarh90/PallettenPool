using FluentValidation;
using SendGridAPI.Models;

namespace SendGridAPI.Validators;

public class CustomerValidator : AbstractValidator<MarketingListDto>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name property is required");
    }
}