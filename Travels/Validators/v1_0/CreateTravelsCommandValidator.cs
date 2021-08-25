using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travels.Infrastructure.Command;

namespace Travels.Api.Validators.v1_0
{
    public class CreateTravelsCommandValidator : AbstractValidator<CreateTravelsCommand>
    {
        public CreateTravelsCommandValidator()
        {
            RuleFor(travel => travel.Name).NotNull();
            RuleFor(travel => travel.Description).NotNull();
        }
    }
}
