using FluentValidation.TestHelper;
using NUnit.Framework;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.CommandValidator;

namespace Travels.Infrastructure.Tests.CommandValidatorTests
{
   internal class DeleteTravelCommandValidatorTests
    {
        [Test]
        public  void Should_no_have_error_when_id_is_specified()
        {
            //Arange
            var validator = new DeleteTravelCommandValidator();
            var model = new DeleteTravelCommand() { Id = 1 };

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldNotHaveValidationErrorFor(model => model.Id);
        }

        [Test]
        public void Should_have_error_when_id_is_Empty()
        {
            //Arange
            var validator = new DeleteTravelCommandValidator();
            var model = new DeleteTravelCommand();

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldHaveValidationErrorFor(model => model.Id);
        }
    }
}
