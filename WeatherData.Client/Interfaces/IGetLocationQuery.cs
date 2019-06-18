using System;
using System.Threading.Tasks;
using WeatherData.Models;
using WeatherData.Models.Location;

namespace WeatherData.Client.Interfaces
{
    public interface IGetLocationQuery : IWebQuery
    {
        Task<LocationResult> GetLocationByCity(string city);

        Task<LocationResult> GetLocationByLatLon(Position position);
    }
}
