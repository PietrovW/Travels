using FluentValidation;
using Travels.Domain.Travel.V1.Queries;

namespace Travels.Api.Validators.v1_0;

public class GetByIdTravelsQuerieValidator : AbstractValidator<GetByIdTravelsQuerie>
{
    public GetByIdTravelsQuerieValidator()
    {
        RuleFor(travel => travel.Id).NotNull();
    }
}
