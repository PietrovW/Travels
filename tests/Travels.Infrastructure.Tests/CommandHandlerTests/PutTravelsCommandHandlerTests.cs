using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Domain.Travel.V1.Commands;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.CommandHandlerTests;

internal class PutTravelsCommandHandlerTests
{
    [Test]
    public async Task PutTravelsCommand_CustomerDataUpdatedOnDatabase()
    {
        //Arange
        var _travelRepositoryMock = new Mock<ITravelRepository>();
        var config = new MapperConfiguration(configuration =>
        {
            configuration.AddMaps(typeof(AutoMapperProfile).Assembly);
        });

        var handler = new UpdateTravelsCommandHandler(_travelRepositoryMock.Object, config.CreateMapper());

        //Act
    //    await handler.Handle(new UpdateTravelsCommand() { Id = 1 }, CancellationToken.None);

        //Asert
        _travelRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Travel>(), CancellationToken.None), Times.Once);
    }
}
