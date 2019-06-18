using System;
namespace WeatherData.Models.Exceptions
{
    public class InvalidCityInputError : Exception
    {
        public InvalidCityInputError(string errorMessage, string city)
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
