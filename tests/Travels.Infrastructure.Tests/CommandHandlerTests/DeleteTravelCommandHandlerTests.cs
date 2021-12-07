using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.CommandHandler;

namespace Travels.Infrastructure.Tests.CommandHandlerTests
{
    internal class DeleteTravelCommandHandlerTests
    {
        [Test]
        public async Task DeleteTravelCommand_CustomerDataUpdatedOnDatabase()
        {
            //Arange
            var _travelRepositoryMock = new Mock<ITravelRepository>();

            var handler = new DeleteTravelCommandHandler(_travelRepositoryMock.Object);

            //Act
            await handler.Handle(new DeleteTravelCommand() { Id = 1}, CancellationToken.None);

            //Asert
            _travelRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Travel>(), CancellationToken.None), Times.Once);
        }
    }
}
