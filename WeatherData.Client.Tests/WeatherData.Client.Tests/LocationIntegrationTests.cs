using System;
using System.Threading.Tasks;
using WeatherData.Client.Concretions;
using WeatherData.Client.Interfaces;
using WeatherData.Models.Location;
using WeatherData.Models.Exceptions;
using Xunit;

namespace WeatherData.Client.Tests
{
    public class LocationIntegrationTests
    {
        [Theory]
        [InlineData("London")]
        [InlineData("Leicester")]
        public async Task GetLocationQuery_GetLocationByCity_Executes_Successfully(string city)
        {
            // Arrange
            IGetLocationQuery query = new GetLocationQuery();

            // Act
            var response = await query.GetLocationByCity(city);

            // Assert
            Assert.Equal(city, response.Title);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Manchesterr")]
        public async Task GetLocationQuery_GetLocationByCity_Executes_Failure(string invalidCity)
        {
            // Arrange
            IGetLocationQuery query = new GetLocationQuery();

            // Act & Assert
            await Assert.ThrowsAsync<LocationByCityNotFoundError>(async () => await query.GetLocationByCity(invalidCity));
        }
            
        [Theory]
        [InlineData("51.506321", "-0.12714")]
        [InlineData("52.637981", "-1.140430")]
        public async Task GetLocationQuery_GetLocationByLatLon_Executes_Successfully(double lat, double lon) 
        {
            // Arrange
            Position position = new Position(lat, lon);
            IGetLocationQuery query = new GetLocationQuery();

            // Act
            var response = await query.GetLocationByLatLon(position);

            // Assert
            Assert.Equal(position.Lat, response.Position.Lat);
            Assert.Equal(position.Lon, response.Position.Lon);
            Assert.True(!string.IsNullOrWhiteSpace(response.Title));
        }
    }
}
