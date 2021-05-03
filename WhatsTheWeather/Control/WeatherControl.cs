using System.Threading.Tasks;
using WhatsTheWeather.Model;
using WhatsTheWeather.UI;

namespace WhatsTheWeather.Control
{
    public class WeatherControl
    {
        //[pqa] Declare the instance for model and view
        private readonly IWeather Weather;
        private readonly IScreen Screen;

        public WeatherControl(IWeather weather, IScreen screen)
        {
            //[pqa] Initialize the values for model and view
            Screen = screen;
            Weather = weather;
        }

        public async Task ShowScreen()
        {
            //[pqa] Display the input
            string ZipCode = Screen.GetInput("Enter ZipCode: ");
            await Weather.Request(ZipCode);

            //[pqa] Get weather code
            int WeatherCode = Weather.Response.Current.WeatherCode;
            string WeatherDesc = Weather.Response.Current.WeatherDescriptions[0];

            //[pqa] Get UV index
            int UVIndex = Weather.Response.Current.UVIndex;

            //[pqa] Get wind speed
            int WindSpeed = Weather.Response.Current.WindSpeed;

            //[pqa] Should I go outside ?
            Screen.ShowOutput("\nShould I go outside?");
            string GoOutside = WeatherCode < 227 ? "Yes. The weather is " + WeatherDesc : "No. The weather is " + WeatherDesc;
            Screen.ShowOutput(GoOutside);

            //[pqa] Should I wear sunscreen ?
            Screen.ShowOutput("\nShould I wear sunscreen?");
            string WearSunscreen = UVIndex > 3 ? "Yes" : "No";
            Screen.ShowOutput(WearSunscreen);

            //[pqa] Can I fly my kite?
            Screen.ShowOutput("\nCan I fly my kite?");
            string FlyKite = (WindSpeed > 15 & WeatherCode < 227) ? "Yes" : "No";
            Screen.ShowOutput(FlyKite);

        }
    }
}
