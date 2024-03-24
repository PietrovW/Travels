using FluentValidation;
namespace Travels.Domain.Travel.V1.Commands;

public class DeleteTravelCommandValidator : AbstractValidator<DeleteTravelCommand>
{
    public DeleteTravelCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
