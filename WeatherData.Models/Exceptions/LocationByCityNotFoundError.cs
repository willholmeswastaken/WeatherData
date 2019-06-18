using System;
namespace WeatherData.Models.Exceptions
{
    public class LocationByCityNotFoundError : Exception
    {
        public LocationByCityNotFoundError(string errorMessage, string city)
            :base(errorMessage)
        {
            this.City = city;
        }

        public string City
        {
            get;
            set;
        }
    }
}
