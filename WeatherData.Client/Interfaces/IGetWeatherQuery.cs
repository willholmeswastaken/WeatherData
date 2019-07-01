using System;
using System.Threading.Tasks;
using WeatherData.Models.Weather;

namespace WeatherData.Client.Interfaces
{
    /// <summary>
    /// Get the weather information of a location with the Where on earth Id (woeId)
    /// </summary>
    public interface IGetWeatherQuery : IWebQuery
    {
        /// <summary>
        /// Gets the todays weather by location.
        /// </summary>
        /// <returns>The todays weather by location.</returns>
        /// <param name="woeId">Where on earth Id.</param>
        Task<WeatherResult> GetTodaysWeatherByLocation(string woeId);

        /// <summary>
        /// Gets the weather for date by location.
        /// </summary>
        /// <returns>The weather for date by location.</returns>
        /// <param name="date">Target date.</param>
        /// <param name="woeId">Where on earth Id.</param>
        Task<WeatherResult> GetWeatherForDateByLocation(DateTime date, string woeId);
    }
}
