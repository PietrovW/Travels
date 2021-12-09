using FluentValidation.TestHelper;
using NUnit.Framework;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.CommandValidator;

namespace Travels.Infrastructure.Tests.CommandValidatorTests
{
   internal class PostTravelsCommandValidatorTests
    {
        [Test]
        public  void Should_no_have_error_when_id_is_specified()
        {
            //Arange
            var validator = new PostTravelsCommandValidator();
            var model = new PostTravelsCommand() { Description="test", Name="test" };

            //Act
            var result = validator.TestValidate(model);

            //Asert
           // result.ShouldNotHaveValidationErrorFor(model => model.Id);
        }

        [Test]
        public void Should_have_error_when_name_is_Empty()
        {
            //Arange
            var validator = new PostTravelsCommandValidator();
            var model = new PostTravelsCommand();

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void Should_have_error_when_description_is_Empty()
        {
            //Arange
            var validator = new PostTravelsCommandValidator();
            var model = new PostTravelsCommand();

            //Act
            var result = validator.TestValidate(model);

            //Asert
            result.ShouldHaveValidationErrorFor(model => model.Description);
        }
    }
}
