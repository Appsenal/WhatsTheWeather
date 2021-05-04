using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WhatsTheWeather.Control;
using WhatsTheWeather.Model;
using WhatsTheWeather.UI;

namespace WhatsTheWeather
{
    public static class Startup
    {
        //[pqa] Startup configuration. Services for UI, control and model are injected here.
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            //[pqa] Application configuration from the appsettings file.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            IConfiguration configuration = builder.Build();
            services.AddSingleton(configuration);

            //[pqa] Other injections
            services.AddTransient<IScreen, Screen>();
            services.AddTransient<WeatherControl>();
            services.AddScoped<IWeather, Weather>();

            return services;
        }


    }
}
