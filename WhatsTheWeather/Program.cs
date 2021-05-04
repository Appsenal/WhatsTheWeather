using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WhatsTheWeather.Control;

namespace WhatsTheWeather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //[pqa] Setup the StartUp to enable dependency injection
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            //[pqa] Show the screen
            await serviceProvider.GetService<WeatherControl>().ShowScreen();
        }
    }
}
