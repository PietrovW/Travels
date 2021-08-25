using FluentValidation;
using Travels.Api.Models.v1_0;

namespace Travels.Api.Validators.v1_0
{
    public class TravelModelsValidator : AbstractValidator<TravelModels>
    {
        public TravelModelsValidator()
        {
            RuleFor(travel => travel.Name).NotNull();
        }
    }
}
