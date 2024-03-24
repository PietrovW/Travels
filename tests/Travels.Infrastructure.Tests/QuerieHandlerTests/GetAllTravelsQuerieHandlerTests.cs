using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Travels.Application.Interfaces;
using Travels.Domain.Travel.V1.Queries;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.QuerieHandlerTests;

internal class GetAllTravelsQuerieHandlerTests
{
    [Test]
    public async Task PostTravelsCommand_CustomerDataUpdatedOnDatabase()
    {
        //Arange
        var _travelRepositoryMock = new Mock<ITravelRepository>();
        var config = new MapperConfiguration(configuration =>
        {
            configuration.AddMaps(typeof(AutoMapperProfile).Assembly);
        });

        var handler = new GetAllTravelsQuerieHandler(_travelRepositoryMock.Object, config.CreateMapper());

        //Act
        await handler.Handle(new GetAllTravelsQuerie(), CancellationToken.None);

        //Asert
        _travelRepositoryMock.Verify(x => x.ListAllAsync(CancellationToken.None), Times.Once);
    }
}
