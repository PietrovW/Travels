using FluentValidation;
using Travels.Core.Queries;

namespace Travels.Api.Validators.v1_0
{
    public class GetByIdTravelsQuerieValidator : AbstractValidator<GetByIdTravelsQuerie>
    {
        public GetByIdTravelsQuerieValidator()
        {
            RuleFor(travel => travel.Id).NotNull();
        }
    }
}
