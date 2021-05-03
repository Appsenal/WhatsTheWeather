using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhatsTheWeather.Model
{
    class Weather : IWeather
    {
        private readonly string AccessKey;
        //private readonly IConfiguration Config;
        private readonly HttpClient Client = new HttpClient();
        //public WeatherDto Response;

        public Weather(IConfiguration config)
        {
            //Config = config;
            //AccessKey = "sdsds";
            AccessKey = config["WeatherStack:access_key"];
        }

        //public WeatherDto GetWeather()
        //{
        //    WeatherDto result=null;

        //    return result;
        //}
        public WeatherDto Response { get; set; }

        public async Task Request(string requestQuery)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("User-Agent", "What is the Weather Application");
            
            //var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            var streamTask = Client.GetStreamAsync(string.Format("http://api.weatherstack.com/current?access_key={0}&query={1}", AccessKey, requestQuery));

            Response = await JsonSerializer.DeserializeAsync<WeatherDto>(await streamTask);

            //foreach (var repo in weather)
            //    Console.WriteLine(repo.Location.Name);
            //var msg = await stringTask;
            //Console.Write(weather.Location.Name);
        }

        public string Test()
        {
            return AccessKey;
        }
    }
}
