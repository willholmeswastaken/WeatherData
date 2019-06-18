using System;
using System.Threading.Tasks;
using WeatherData.Models.Weather;

namespace WeatherData.Client.Interfaces
{
    public interface IGetWeatherQuery : IWebQuery
    {
        Task<WeatherResult> GetTodaysWeatherByLocation(string woeId);

        Task<WeatherResult> GetWeatherForDateByLocation(DateTime date, string woeId);
    }
}
