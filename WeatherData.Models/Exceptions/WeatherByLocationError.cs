using System;
namespace WeatherData.Models.Exceptions
{
    public class WeatherByLocationError : Exception
    {
        public WeatherByLocationError(string errorMessage, string woeId)
            :base(errorMessage)
        {
            this.WoeId = woeId;
        }

        public string WoeId
        {
            get;
            set;
        }
    }
}
