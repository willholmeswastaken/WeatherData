using System;
using WeatherData.Models.Exceptions;

namespace WeatherData.Utils
{
    public static class StringExtensions
    {
        public static void ValidateCity(this string city) 
        {
            if(string.IsNullOrWhiteSpace(city)) 
            {
                throw new InvalidCityInputError("Empty city entered", city);
            }
        }
    }
}
