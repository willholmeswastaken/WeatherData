using System;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetWeather().GetAwaiter().GetResult();
        }

        static async Task GetWeather() {
            bool exitApp = false;
            IWeatherDataService weatherDataService = new WeatherDataService();

            while (!exitApp)
            {
                Console.WriteLine("What city would you like to get the weather for?");
                string location = Console.ReadLine();

                var response = await weatherDataService.GetTodaysWeatherDataByCity(location);

                var weather = response
                    .ConsolidatedWeather
                    .OrderByDescending(x => x.Predictability)
                    .First();
                
                Console.WriteLine($"The minimum temperature for {response.Title} is {Math.Round(weather.MinTemp)}c");
                Console.WriteLine($"The maxiumum temperature for {response.Title} is {Math.Round(weather.MaxTemp)}c");
                Console.WriteLine($"The most likely temperature for {response.Title} is {Math.Round(weather.TheTemp)}c");

                Console.WriteLine("Would you like to get the weather for another city? Y/N");
                string anotherCity = Console.ReadLine().ToLower();
                while (!(anotherCity == "n" || anotherCity == "y"))
                {
                    Console.WriteLine("Please enter y or n again!");
                    anotherCity = Console.ReadLine().ToLower();
                }

                exitApp = anotherCity.Equals("n");
            }
        }
    }
}
