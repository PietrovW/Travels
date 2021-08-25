using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Travels.Infrastructure.Command;

namespace Travels.Infrastructure.CommandValidator
{
    public class DeleteTravelCommandValidator : AbstractValidator<DeleteTravelCommand>
    {
        public DeleteTravelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
