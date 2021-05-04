using System.Threading.Tasks;

namespace WhatsTheWeather.Model
{
    public interface IWeather
    {
        public WeatherDto Response { get; set; }
        
        public Task Request(string requestQuery);

        //public string Test();
    }
}
