using FluentValidation;

namespace Travels.Domain.Travel.V1.Commands;

public class CreationTravelsCommandValidator : AbstractValidator<CreationTravelsCommand>
{
    public CreationTravelsCommandValidator()
    {
        RuleFor(travel => travel.Name).NotNull();
        RuleFor(travel => travel.Description).NotNull();
    }
}
