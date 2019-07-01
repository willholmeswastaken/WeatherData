using System;
using System.Threading.Tasks;
using WeatherData.Models.Weather;

namespace WeatherData
{
    public interface IWeatherDataService : IDisposable
    {
        Task<WeatherResult> GetTodaysWeatherDataByCity(string city);

        Task<WeatherResult> GetTodaysWeatherDataByLatLon(double lat, double lon);

        Task<WeatherResult> GetWeatherDataForDateByCity(string city, DateTime date);

        Task<WeatherResult> GetWeatherDataForDateByLatLon(double lat, double lon, DateTime date);
    }
}
