# WeatherData 🌦
A c# library to wrap a weather api and make it easy to use &amp; integrate.
https://www.metaweather.com/api/

## Nuget Package Url:
https://www.nuget.org/packages/WeatherData.NET

## Getting Started
```
Install-Package WeatherData.NET -Version 1.0.5
```

## Using the library
The weather data service implements IDisposable so ensure you wrap your usage with a using() or implement IDisposable wherever you are using the library to take hold of the .Dispose() functionality.

```
using(IWeatherDataService weatherDataService = new WeatherDataService()) {

var todayByCityResponse = await weatherDataService
                                .GetTodaysWeatherDataByCity("London");

var todayByLatLonResponse = await weatherDataService
                                .GetTodaysWeatherDataByLatLon(51.5074, 0.1278);

var specificDateAndCityResponse = await weatherDataService
                                .GetWeatherDataForDateByCity("London", DateTime.Now);

var specificDateAndLatLonResponse = await weatherDataService
                                .GetWeatherDataForDateByLatLon(51.5074, 0.1278, DateTime.Now);
}

```
[See example project to find an example implementation.](https://github.com/willholmeswastaken/WeatherData/blob/master/WeatherData.Example/Program.cs)
