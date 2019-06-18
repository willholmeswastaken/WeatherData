using System;
using System.Threading.Tasks;
using WeatherData.Client.Concretions;
using WeatherData.Client.Interfaces;
using WeatherData.Models.Location;
using WeatherData.Models.Weather;
using WeatherData.Utils;

namespace WeatherData
{
    public class WeatherDataService : IWeatherDataService, IDisposable
    {
        public WeatherDataService()
        {
            this.locationQuery = new GetLocationQuery();
            this.weatherQuery = new GetWeatherQuery();
        }

        public WeatherDataService(GetLocationQuery locationQuery, GetWeatherQuery weatherQuery)
        {
            this.locationQuery = locationQuery;
            this.weatherQuery = weatherQuery;
        }

        private readonly IGetLocationQuery locationQuery;
        private readonly IGetWeatherQuery weatherQuery;

        public async Task<WeatherResult> GetTodaysWeatherDataByCity(string city)
        {
            city.ValidateCity();

            var location = await this
                .locationQuery
                .GetLocationByCity(city);

            return await this
                .weatherQuery
                .GetTodaysWeatherByLocation(location
                                            .WoeId
                                            .ToString());
            
        }

        public async Task<WeatherResult> GetTodaysWeatherDataByLatLon(double lat, double lon)
        {
            var position = new Position(lat, lon);

            var location = await this
                .locationQuery
                .GetLocationByLatLon(position);

            return await this
                .weatherQuery
                .GetTodaysWeatherByLocation(location
                                            .WoeId
                                            .ToString());
        }

        public async Task<WeatherResult> GetWeatherDataForDateByCity(string city, DateTime date)
        {
            city.ValidateCity();

            var location = await this
                .locationQuery
                .GetLocationByCity(city);

            return await this
                .weatherQuery
                .GetWeatherForDateByLocation(date,
                                             location
                                            .WoeId
                                            .ToString());
        }

        public async Task<WeatherResult> GetWeatherDataForDateByLatLon(double lat, double lon, DateTime date)
        {
            var position = new Position(lat, lon);

            var location = await this
                .locationQuery
                .GetLocationByLatLon(position);

            return await this
                .weatherQuery
                .GetWeatherForDateByLocation(date,
                                             location
                                            .WoeId
                                            .ToString());
        }

        public void Dispose()
        {
            this.locationQuery.Dispose();
            this.weatherQuery.Dispose();
        }
    }
}
