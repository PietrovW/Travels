using FluentValidation.TestHelper;
using NUnit.Framework;
using Travels.Domain.Travel.V1.Commands;

namespace Travels.Infrastructure.Tests.CommandValidatorTests;

internal class PostTravelsCommandValidatorTests
{
    [Test]
    public  void Should_no_have_error_when_id_is_specified()
    {
        //Arange
        var validator = new CreationTravelsCommandValidator();
        var model = new CreationTravelsCommand() { Description="test", Name="test" };

        //Act
        var result = validator.TestValidate(model);

        //Asert
       // result.ShouldNotHaveValidationErrorFor(model => model.Id);
    }

    [Test]
    public void Should_have_error_when_name_is_Empty()
    {
        //Arange
        var validator = new CreationTravelsCommandValidator();
        var model = new CreationTravelsCommand();

        //Act
        var result = validator.TestValidate(model);

        //Asert
        result.ShouldHaveValidationErrorFor(model => model.Name);
    }

    [Test]
    public void Should_have_error_when_description_is_Empty()
    {
        //Arange
        var validator = new CreationTravelsCommandValidator();
        var model = new CreationTravelsCommand();

        //Act
        var result = validator.TestValidate(model);

        //Asert
        result.ShouldHaveValidationErrorFor(model => model.Description);
    }
}
