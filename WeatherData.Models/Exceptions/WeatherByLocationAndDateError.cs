using System;
namespace WeatherData.Models.Exceptions
{
    public class WeatherByLocationAndDateError : Exception
    {
        public WeatherByLocationAndDateError(string errorMessage, string woeId, DateTime date)
            :base(errorMessage)
        {
            this.WoeId = woeId;
            this.Date = date;
        }

        public string WoeId
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }
    }
}
