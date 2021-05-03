using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTheWeather.UI
{
    public interface IScreen
    {
        public void ShowOutput(string output);
        public string GetInput(string inputLabel);
    }
}
