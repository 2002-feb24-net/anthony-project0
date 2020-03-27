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
                System.Console.WriteLine("Welcome to Balloon Party!!\nPlease select an option or Press Zero to exit\n\n1: Show Previous Orders\n2: See Store Locations\n3: Return to Login\n\n0: Exit Application");
                int input = int.Parse(Console.ReadLine());
                if(input == 1)
                {
                    System.Console.Clear();
                    status = false;
                    CustomerData.ShowCustomersOrders();
                }
                if(input == 2)
                {
                    System.Console.Clear();
                    status = false;
                    CustomerData.PlaceOrder();
                }
                if(input == 3)
                {
                    System.Console.Clear();
                    status = false;
                    Login.mainLogin();
                }
                if(input == 0)
                {   
                    status = false;
                    Environment.Exit(-1);
                }
            } while(status);
        }
    }
}