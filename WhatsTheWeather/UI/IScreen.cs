
namespace WhatsTheWeather.UI
{
    public interface IScreen
    {
        public void ShowOutput(string output);
        public string GetInput(string inputLabel);
    }
}
