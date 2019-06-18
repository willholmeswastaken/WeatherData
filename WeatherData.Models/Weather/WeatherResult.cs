using System;
using Newtonsoft.Json;
using WeatherData.Models.Location;

namespace WeatherData.Models.Weather
{
    public class WeatherResult
    {
        public WeatherResult()
        {
        }

        [JsonProperty("consolidated_weather")]
        public ConsolidatedWeather[] ConsolidatedWeather { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("sun_rise")]
        public DateTimeOffset SunRise { get; set; }

        [JsonProperty("sun_set")]
        public DateTimeOffset SunSet { get; set; }

        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }

        [JsonProperty("parent")]
        public LocationResult Parent { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("woeid")]
        public long WoeId { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
