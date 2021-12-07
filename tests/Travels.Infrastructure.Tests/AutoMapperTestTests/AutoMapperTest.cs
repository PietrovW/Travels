using AutoMapper;
using NUnit.Framework;
using Travels.Infrastructure.Profiles;

namespace Travels.Infrastructure.Tests.AutoMapperTestTests
{
    internal class ProfilesTest
    {
        [Test]
        public void WhenProfilesAreConfigured_ItShouldNotThrowException()
        {
            // Arrange
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddMaps(typeof(AutoMapperProfile).Assembly);
            });

            // Assert
            config.AssertConfigurationIsValid();
        }
    }
}
