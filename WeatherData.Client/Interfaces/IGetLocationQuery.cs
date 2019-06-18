using System;
using System.Threading.Tasks;
using WeatherData.Models;

namespace WeatherData.Client.Interfaces
{
    public interface IGetLocationQuery : IWebQuery
    {
        Task<LocationResult> GetLocationByCity(string city);

        Task<LocationResult> GetLocationByLatLon(Position position);
    }
}
