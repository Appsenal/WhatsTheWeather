using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WhatsTheWeather.Model
{
    class Weather : IWeather
    {
        //[pqa] Declare needed fields.
        private readonly string AccessKey;
        private readonly HttpClient Client = new HttpClient();

        public Weather(IConfiguration config)
        {
            //[pqa] Retrieve the API access key from the configuration.
            AccessKey = config["WeatherStack:access_key"];
        }

        //[pqa] API response will be stored in this method.
        public WeatherDto Response { get; set; }

        public async Task Request(string requestQuery)
        {
            //[pqa] Send request and deserialize the response from the weather API
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("User-Agent", "What is the Weather Application");
            
            //[pqa] Pass the access key and the request key here
            var streamTask = Client.GetStreamAsync(string.Format("http://api.weatherstack.com/current?access_key={0}&query={1}", AccessKey, requestQuery));

            //[pqa] Deserialize response to Response method
            Response = await JsonSerializer.DeserializeAsync<WeatherDto>(await streamTask);

        }

        //public string Test()
        //{
        //    return AccessKey;
        //}
    }
}
