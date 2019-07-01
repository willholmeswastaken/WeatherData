using System;
using System.Net.Http;

namespace WeatherData.Client.Interfaces
{
    /// <summary>
    /// The base web query implementing httpclient as a minimum to perform web queries.
    /// </summary>
    public interface IWebQuery : IDisposable
    {
        HttpClient Client { get; set; }
    }
}
