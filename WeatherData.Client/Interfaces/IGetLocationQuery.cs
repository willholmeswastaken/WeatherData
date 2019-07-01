using System;
using System.Threading.Tasks;
using WeatherData.Models;
using WeatherData.Models.Location;

namespace WeatherData.Client.Interfaces
{
    /// <summary>
    /// Get the information of a location through either, city or latlon.
    /// </summary>
    public interface IGetLocationQuery : IWebQuery
    {
        /// <summary>
        /// Gets the location by city.
        /// </summary>
        /// <returns>The location by city.</returns>
        /// <param name="city">City name.</param>
        Task<LocationResult> GetLocationByCity(string city);

        /// <summary>
        /// Gets the location by lat lon.
        /// </summary>
        /// <returns>The location by lat lon.</returns>
        /// <param name="position">Contains lat and lon properties.</param>
        Task<LocationResult> GetLocationByLatLon(Position position);
    }
}
