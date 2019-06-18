using System;
namespace WeatherData.Models.Exceptions
{
    public class LocationByPositionNotFoundError : Exception
    {
        public LocationByPositionNotFoundError(string errorMessage, Position position)
            :base(errorMessage)
        {
            this.Position = position;
        }

        public Position Position
        {
            get;
            set;
        }
    }
}
