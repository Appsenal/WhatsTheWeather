using System.Text.Json.Serialization;

namespace WhatsTheWeather.Model
{
    //[pqa] The structures of this class is similar to the JSON response of the weather API.
    //[pqa] I only put selected fields here but this can easily be expanded with minimal impact to the other classes.
    public class WeatherDto
    {
        [JsonPropertyName("request")]
        public RequestDto Request { get; set; }
        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }
        [JsonPropertyName("current")]
        public CurrentDto Current { get; set; }
    }

    public class CurrentDto
    {
        [JsonPropertyName("observation_time")]
        public string Time { get; set; }
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }
        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }
        [JsonPropertyName("weather_descriptions")]
        public string[] WeatherDescriptions { get; set; }
        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("uv_index")]
        public int UVIndex { get; set; }
    }

    public class LocationDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
    }

    public class RequestDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("query")]
        public string Query { get; set; }
    }
}