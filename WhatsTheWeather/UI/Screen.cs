using System;

namespace WhatsTheWeather.UI
{
    public class Screen : IScreen
    {
        public Screen ()
        {
            //[pqa] Nothing to do here... yet.
        }

        public void ShowOutput(string output)
        {
            //[pqa] A very simple method to output the text to the console
            Console.WriteLine(output);
        }

        public string GetInput(string inputLabel)
        {
            //[pqa] Instead of the usual readline, this method will read the key then concatenate it into a string if it is numeric or an alphabet. 
            //[pqa] It will ignore all other keys aside from Space, Enter and Esc.

            //[pqa] Initialize the needed variables
            ConsoleKeyInfo KeyInfo;
            string Output = "";

            //[pqa] Show the label text to the console screen.
            Console.WriteLine("(Press ESC to exit)");
            Console.Write(inputLabel);
            
            //[pqa] Loop through all the read keys and stop when Enter or Esc is pressed
            do
            {
                //[pqa] read the key
                KeyInfo = Console.ReadKey();

                //[pqa] Is key alphanumeric or space?
                if (Char.IsNumber(KeyInfo.KeyChar) || Char.IsLetter(KeyInfo.KeyChar) || KeyInfo.Key == ConsoleKey.Spacebar)
                {
                    //[pqa] Append to the output
                    Output = String.Concat(Output, KeyInfo.KeyChar.ToString());
                }
            } while (KeyInfo.Key != ConsoleKey.Escape & KeyInfo.Key != ConsoleKey.Enter);

            //[pqa] Exit from the console when Esc is pressed.
            if (KeyInfo.Key == ConsoleKey.Escape) Environment.Exit(0);

            //[pqa] This is to the add one line to the console display and not overwrite the previous text.
            Console.WriteLine("");

            return Output;
        }
    }
}
