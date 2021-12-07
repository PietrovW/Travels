using FluentValidation;
using Travels.Infrastructure.Command;

namespace Travels.Infrastructure.CommandValidator
{
    public class PostTravelsCommandValidator : AbstractValidator<PostTravelsCommand>
    {
        public PostTravelsCommandValidator()
        {
            RuleFor(travel => travel.Name).NotNull();
            RuleFor(travel => travel.Description).NotNull();
        }
    }
}
