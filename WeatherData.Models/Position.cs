using System;
namespace WeatherData.Models
{
    public class Position
    {
        public Position()
        {
        }

        public Position(double lat, double lon)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        public double Lat
        {
            get;
            set;
        }

        public double Lon
        {
            get;
            set;
        }
    }
}
