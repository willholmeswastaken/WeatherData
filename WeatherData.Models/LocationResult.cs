using System;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherData.Models
{
    public class LocationResult
    {
        public LocationResult()
        {
        }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("location_type")]
        public string LocationType { get; set; }
        [JsonProperty("woeid")]
        public int WoeId { get; set; }
        [JsonProperty("latt_long")]
        public string LatLong { get; set; }

        public Position Position {
            get {
                if(!string.IsNullOrWhiteSpace(this.LatLong)) {
                    double[] latLon = this
                        .LatLong
                        .Split(',')
                        .Select(x => double.Parse(x))
                        .ToArray();
                    return new Position(latLon[0], latLon[1]);
                }
                return null;
            }
        }
    }
}
