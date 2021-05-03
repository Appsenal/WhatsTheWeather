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
        //public static IConfiguration Configuration { get; }
        //public static Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            IConfiguration configuration = builder.Build();
            
            services.AddSingleton(configuration);

            services.AddTransient<IScreen, Screen>();
            services.AddTransient<WeatherControl>();
            services.AddScoped<IWeather, Weather>();

            return services;
        }


    }
}
