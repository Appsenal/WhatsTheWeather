using System;

namespace WhatsTheWeather.UI
{
    public class Screen : IScreen
    {
        public Screen ()
        {

        }

        public void ShowOutput(string output)
        {
            Console.WriteLine(output);
        }

        public string GetInput(string inputLabel)
        {
            Console.Write(inputLabel);
            return Console.ReadLine(); 
        }
    }
}
