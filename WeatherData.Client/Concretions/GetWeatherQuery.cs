using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherData.Client.Interfaces;
using WeatherData.Models;
using WeatherData.Models.Exceptions;
using WeatherData.Models.Weather;
using System.Linq;

namespace WeatherData.Client.Concretions
{
    public class GetWeatherQuery : IGetWeatherQuery
    {
        public GetWeatherQuery()
        {
            this.Client = new HttpClient()
            {
                BaseAddress = new Uri($"{Constants.API_URL}{Constants.WEATHER_LOCATION_ENDPOINT}")
            };
        }

        public GetWeatherQuery(HttpClient client)
        {
            this.Client = client;
        }

        public HttpClient Client
        {
            get;
            set;
        }

        public void Dispose()
        {
            this.Client.Dispose();
        }

        public async Task<WeatherResult> GetTodaysWeatherByLocation(string woeId)
        {
            var response = await this
                .Client
                .GetAsync(woeId);

            if(!response.IsSuccessStatusCode) {
                throw new WeatherByLocationError("Failed to get weather by location", woeId);
            }

            return JsonConvert
                .DeserializeObject<WeatherResult>(await response
                .Content
                .ReadAsStringAsync());
        }

        public async Task<WeatherResult> GetWeatherForDateByLocation(DateTime date, string woeId)
        {
            var response = await this
                .Client
                .GetAsync($"{woeId}/{date.ToString("yyyy/MM/dd")}");

            if (!response.IsSuccessStatusCode)
            {
                throw new WeatherByLocationAndDateError(
                    "Failed to get weather by location and date",
                    woeId,
                    date);
            }

            var result = new WeatherResult();
            result.ConsolidatedWeather = JsonConvert
                    .DeserializeObject<ConsolidatedWeather[]>
                    (await response
                        .Content
                     .ReadAsStringAsync());
            result.WoeId = long.Parse(woeId);
            
            return result;
        }
    }
}
