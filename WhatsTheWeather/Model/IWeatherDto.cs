using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheWeather.Model
{
    public interface IWeatherDto
    {
        IRequestDto Request { get; set; }
        ILocationDto Location { get; set; }
        ICurrentDto Current { get; set; }
    }

    public interface IRequestDto
    {
        string Time { get; set; }
        int Temperature { get; set; }
        int WeatherCode { get; set; }
        string WeatherDescriptions { get; set; }
        int WindSpeed { get; set; }
        int UVIndex { get; set; }
    }

    public interface ILocationDto
    {
        string Name { get; set; }
        string Country { get; set; }
        string Region { get; set; }
    }

    public interface ICurrentDto
    {
        string Type { get; set; }
        string Query { get; set; }
    }
}
