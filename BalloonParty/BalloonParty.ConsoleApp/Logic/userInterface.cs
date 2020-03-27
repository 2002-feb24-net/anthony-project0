using System;


namespace BalloonParty.ConsoleApp.Logic
{
    public class userInterface
    {
        public static void userMainMenu()
        {
            bool status = true;
            do
            {
                System.Console.WriteLine("Welcome to Balloon Party!!\nPlease select the coorisponding number  with the store you would like to visit or Press Zero to exit\n\n");
                StoreData.ShowStores();
                int input = int.Parse(Console.ReadLine());
                ProductData.ShowInventory(input);
                if(input == 0)
                {   
                    Environment.Exit(-1);
                }
                status = false;
            } while(status);
        }
    }
}