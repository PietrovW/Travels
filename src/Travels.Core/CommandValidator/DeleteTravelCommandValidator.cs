using FluentValidation;
using Travels.Infrastructure.Command;

namespace Travels.Core.CommandValidator
{
    public class DeleteTravelCommandValidator : AbstractValidator<DeleteTravelCommand>
    {
        public DeleteTravelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
