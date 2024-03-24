using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Domain.Travel.V1.Commands;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.CommandHandlerTests;

internal class PostTravelsCommandHandlerTests
{
    [Test]
    public async Task PostTravelsCommand_CustomerDataUpdatedOnDatabase()
    {
        //Arange
      //  var _mediatorMock = new Mock<IMediator>();
        var _travelRepositoryMock = new Mock<ITravelRepository>();
        var config = new MapperConfiguration(configuration =>
        {
            configuration.AddMaps(typeof(AutoMapperProfile).Assembly);
        });
      
        var handler = new CreationTravelsCommandHandler(_travelRepositoryMock.Object, config.CreateMapper());

        //Act
        await handler.Handle(new CreationTravelsCommand() { Created= DateTimeOffset.UtcNow, Name="test" }, CancellationToken.None);

        //Asert
        _travelRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Travel>(), CancellationToken.None), Times.Once);
    }
}
