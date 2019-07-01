using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherData.Client.Interfaces;
using WeatherData.Models;
using WeatherData.Models.Exceptions;
using WeatherData.Models.Location;

namespace WeatherData.Client.Concretions
{
    public class GetLocationQuery : IGetLocationQuery
    {
        public HttpClient Client { get; set; }

        public GetLocationQuery()
        {
            this.Client = new HttpClient() {
                BaseAddress = new Uri($"{Constants.API_URL}{Constants.LOCATION_SEARCH_ENDPOINT}")
            };
        }

        public GetLocationQuery(HttpClient client)
        {
            this.Client = client;
        }

        public void Dispose()
        {
            this.Client.Dispose();
        }

        public async Task<LocationResult> GetLocationByCity(string city)
        {
            var response = await this
                .Client
                .GetAsync($"?query={city}");

            if(!response.IsSuccessStatusCode) {
                throw new LocationByCityNotFoundError("Issue querying location to the api", city);
            }

            var result = JsonConvert
                .DeserializeObject<LocationResult[]>(await response
                .Content
                .ReadAsStringAsync());

            if(!result.Any()) 
            {
                throw new LocationByCityNotFoundError("No locations found from api response", city);
            }

            return result[0];
        }

        public async Task<LocationResult> GetLocationByLatLon(Position position)
        {
            var response = await this
                .Client
                .GetAsync($"?lattlong={position.Lat},{position.Lon}");

            if (!response.IsSuccessStatusCode)
            {
                throw new LocationByPositionNotFoundError("Issue querying location to the api", position);
            }

            var result = JsonConvert
                .DeserializeObject<LocationResult[]>(await response
                .Content
                .ReadAsStringAsync());

            if (!result.Any())
            {
                throw new LocationByPositionNotFoundError("No locations found from api response", position);
            }

            return result[0];
        }
    }
}
