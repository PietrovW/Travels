using FluentValidation;
using Travels.Infrastructure.Command;

namespace Travels.Api.Validators.v1_0
{
    public class DeleteTravelCommandValidator: AbstractValidator<DeleteTravelCommand>
    {
        public DeleteTravelCommandValidator()
        {
            RuleFor(travel => travel.Id).NotNull();
        }
    }
}
