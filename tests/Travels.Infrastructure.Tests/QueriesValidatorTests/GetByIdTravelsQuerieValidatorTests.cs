using FluentValidation.TestHelper;
using NUnit.Framework;
using Travels.Domain.Travel.V1.Queries;

namespace Travels.Infrastructure.Tests.QueriesValidatorTests;

internal class GetByIdTravelsQuerieValidatorTests
{
        [Test]
        public void Should_no_have_error_when_id_is_specified()
        {
            //Arange
            var validator = new GetByIdTravelsQuerieValidator();
            var model = new GetByIdTravelsQuerie() { Id = 1 };

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldNotHaveValidationErrorFor(model => model.Id);
        }

        [Test]
        public void Should_have_error_when_id_is_Empty()
        {
            //Arange
            var validator = new GetByIdTravelsQuerieValidator();
            var model = new GetByIdTravelsQuerie();

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldHaveValidationErrorFor(model => model.Id);
        }
}
