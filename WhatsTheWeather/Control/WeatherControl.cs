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
            string ZipCode = Screen.GetInput("Enter Your ZipCode/Place: ");
            //Screen.ShowOutput("Enter ZipCode: "+ ZipCode);
            Screen.ShowOutput("Please wait while retrieving the weather for "+ ZipCode +"...\n");

            await Weather.Request(ZipCode);

            if (Weather.Response.Request != null) {
                Screen.ShowOutput("You are in "+Weather.Response.Location.Name+", " + Weather.Response.Location.Region + ", " + Weather.Response.Location.Country);

                //[pqa] Get weather code
                int WeatherCode = Weather.Response.Current.WeatherCode;
                string WeatherDesc = Weather.Response.Current.WeatherDescriptions[0];

                //[pqa] Get UV index
                int UVIndex = Weather.Response.Current.UVIndex;

                //[pqa] Get wind speed
                int WindSpeed = Weather.Response.Current.WindSpeed;

                //[pqa] Should I go outside ?
                Screen.ShowOutput("\nShould I go outside?");
                string GoOutside = WeatherCode < 227 ? "YES. The weather is " + WeatherDesc : "NO. The weather is " + WeatherDesc;
                Screen.ShowOutput(GoOutside);

                //[pqa] Should I wear sunscreen ?
                Screen.ShowOutput("\nShould I wear sunscreen?");
                string WearSunscreen = UVIndex > 3 ? "YES. The UV is over 3, UV Index: "+UVIndex.ToString() : "NO. The UV is safe, UV Index: " + UVIndex.ToString();
                Screen.ShowOutput(WearSunscreen);

                //[pqa] Can I fly my kite?
                Screen.ShowOutput("\nCan I fly my kite?");
                string FlyKite = (WindSpeed > 15 & WeatherCode < 227) ? "YES. It is not raining and the wind speed is over 15. Wind Speed: "+ WindSpeed.ToString(): "NO. It is raining or the wind speed is low. Wind Speed: " + WindSpeed.ToString();
                Screen.ShowOutput(FlyKite);
            }
            else
            {
                Screen.ShowOutput("Your query for ZipCode/Place "+ZipCode+" did not return a value. Please try again.");
            }

            Screen.ShowOutput("\n");
            await ShowScreen();
        }
    }
}
