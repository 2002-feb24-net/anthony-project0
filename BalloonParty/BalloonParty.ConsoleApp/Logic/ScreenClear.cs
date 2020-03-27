using System;
namespace BalloonParty.ConsoleApp
{
    public class ScreenClear
    {

        public static void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch (System.Exception)
            {
                
                System.Console.WriteLine("Error Clearing Screen\n");
            }
        }

    }
}