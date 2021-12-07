using FluentValidation;
using Travels.Core.Queries;

namespace Travels.Infrastructure.QueriesValidator
{
    public class GetByIdTravelsQuerieValidator : AbstractValidator<GetByIdTravelsQuerie>
    {
        public GetByIdTravelsQuerieValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
