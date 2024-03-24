using FluentValidation;

namespace Travels.Domain.Travel.V1.Queries;

public class GetByIdTravelsQuerieValidator : AbstractValidator<GetByIdTravelsQuerie>
{
    public GetByIdTravelsQuerieValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

