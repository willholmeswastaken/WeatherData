using System;
using System.Threading.Tasks;
using WeatherData.Client.Concretions;
using WeatherData.Client.Interfaces;
using WeatherData.Models.Exceptions;
using Xunit;

namespace WeatherData.Client.Tests
{
    public class WeatherIntegrationTests
    {
        [Theory]
        [InlineData("44418")]
        [InlineData("26062")]
        public async Task GetWeatherQuery_GetTodaysWeatherByLocation_Executes_Successfully(string woeId) 
        {
            // Arrange
            IGetWeatherQuery query = new GetWeatherQuery();

            // Act
            var response = await query.GetTodaysWeatherByLocation(woeId);

            // Assert
            Assert.NotNull(response.ConsolidatedWeather);
            Assert.Equal(long.Parse(woeId), response.WoeId);
        }

        [Theory]
        [InlineData("444181")]
        [InlineData("260621")]
        public async Task GetWeatherQuery_GetTodaysWeatherByLocation_Executes_Failure(string invalidWoeId)
        {
            // Arrange
            IGetWeatherQuery query = new GetWeatherQuery();

            // Act & Assert
            await Assert.ThrowsAsync<WeatherByLocationError>(async () => await query.GetTodaysWeatherByLocation(invalidWoeId));
        }

        [Theory]
        [InlineData("44418")]
        [InlineData("26062")]
        public async Task GetWeatherQuery_GetWeatherForDateByLocation_Executes_Successfully(string woeId)
        {
            // Arrange
            DateTime dateRequested = DateTime.Now.Date;
            IGetWeatherQuery query = new GetWeatherQuery();

            // Act
            var response = await query.GetWeatherForDateByLocation(dateRequested, woeId);

            // Assert
            Assert.NotNull(response.ConsolidatedWeather);
            Assert.Equal(long.Parse(woeId), response.WoeId);
        }

        [Theory]
        [InlineData("444181")]
        [InlineData("260621")]
        public async Task GetWeatherQuery_GetWeatherForDateByLocation_Executes_Failure(string invalidWoeId)
        {
            // Arrange
            DateTime dateRequested = DateTime.Now.Date;
            IGetWeatherQuery query = new GetWeatherQuery();

            // Act & Assert
            await Assert.ThrowsAsync<WeatherByLocationAndDateError>(async () => await query.GetWeatherForDateByLocation(dateRequested, invalidWoeId));
        }
    }
}
