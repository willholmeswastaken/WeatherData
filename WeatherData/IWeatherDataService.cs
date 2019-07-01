using System;
using System.Threading.Tasks;
using WeatherData.Models.Weather;

namespace WeatherData
{
    /// <summary>
    /// The core weather data service to obtain weather results in applications.
    /// </summary>
    public interface IWeatherDataService : IDisposable
    {
        /// <summary>
        /// Gets the todays weather data by city.
        /// </summary>
        /// <returns>The todays weather data by city.</returns>
        /// <param name="city">Target city.</param>
        Task<WeatherResult> GetTodaysWeatherDataByCity(string city);

        /// <summary>
        /// Gets the todays weather data by lat lon.
        /// </summary>
        /// <returns>The todays weather data by lat lon.</returns>
        /// <param name="lat">Lat.</param>
        /// <param name="lon">Lon.</param>
        Task<WeatherResult> GetTodaysWeatherDataByLatLon(double lat, double lon);

        /// <summary>
        /// Gets the weather data for date by city.
        /// </summary>
        /// <returns>The weather data for date by city.</returns>
        /// <param name="city">Target city.</param>
        /// <param name="date">Target date.</param>
        Task<WeatherResult> GetWeatherDataForDateByCity(string city, DateTime date);

        /// <summary>
        /// Gets the weather data for date by lat lon.
        /// </summary>
        /// <returns>The weather data for date by lat lon.</returns>
        /// <param name="lat">Lat.</param>
        /// <param name="lon">Lon.</param>
        /// <param name="date">Target date.</param>
        Task<WeatherResult> GetWeatherDataForDateByLatLon(double lat, double lon, DateTime date);
    }
}
