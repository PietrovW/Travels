using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.CommandHandler;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.CommandHandlerTests
{
    internal class PostTravelsCommandHandlerTests
    {
        [Test]
        public async Task PostTravelsCommand_CustomerDataUpdatedOnDatabase()
        {
            //Arange
            var _mediatorMock = new Mock<IMediator>();
            var _travelRepositoryMock = new Mock<ITravelRepository>();
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddMaps(typeof(AutoMapperProfile).Assembly);
            });
          
            var handler = new PostTravelsCommandHandler(_travelRepositoryMock.Object, config.CreateMapper());

            //Act
            await handler.Handle(new PostTravelsCommand() { Created= DateTimeOffset.UtcNow, Name="test" }, CancellationToken.None);

            //Asert
            _travelRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Travel>(), CancellationToken.None), Times.Once);
        }
    }
}
