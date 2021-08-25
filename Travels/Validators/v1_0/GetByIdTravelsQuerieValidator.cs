using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travels.Infrastructure.Queries;

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
