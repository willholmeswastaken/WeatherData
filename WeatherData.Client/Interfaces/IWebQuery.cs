using System;
using System.Net.Http;

namespace WeatherData.Client.Interfaces
{
    public interface IWebQuery : IDisposable
    {
        HttpClient Client { get; set; }
    }
}
