using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.CommandHandler;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.CommandHandlerTests
{
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

            var handler = new PutTravelsCommandHandler(_travelRepositoryMock.Object, config.CreateMapper());

            //Act
            await handler.Handle(new PutTravelsCommand() { Id = 1 }, CancellationToken.None);

            //Asert
            _travelRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Travel>(), CancellationToken.None), Times.Once);
        }
    }
}
