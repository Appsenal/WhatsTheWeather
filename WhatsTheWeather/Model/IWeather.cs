using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheWeather.Model
{
    public interface IWeather
    {
        public WeatherDto Response { get; set; }
        //public WeatherDto GetWeather();
        public Task Request(string requestQuery);

        public string Test();
    }
}
