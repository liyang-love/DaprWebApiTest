using Dapr.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DaprClientTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var daprClient = new DaprClientBuilder().Build();

            var confirmation = daprClient.InvokeMethodAsync<List<WeatherForecast>>(HttpMethod.Get, "DaprWebApiTestApp", "api/WeatherForecast/");

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(confirmation.Result));

            Console.WriteLine("Hello World!");
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
