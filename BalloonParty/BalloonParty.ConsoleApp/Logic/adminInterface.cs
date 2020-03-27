using System;

namespace BalloonParty.ConsoleApp.Logic
{
    public class adminInterface
    {
        public static void adminMainMenu()
        {
            
            bool status = true;
            do
            {
                System.Console.WriteLine("Please select the coorisponding number of your task\n1: Add New Store\n2: Add New Products\n3: Add New Customer\n4: Return to Login\n\n4: Exit Application");
                int input = int.Parse(Console.ReadLine());
                
                if(input == 1)
                {
                    System.Console.Clear();
                    StoreData.AddStore();
                }
                if(input == 2)
                {
                    System.Console.Clear();
                    ProductData.AddProduct();
                }
                if(input == 3)
                {
                    System.Console.Clear();
                    CustomerData.AddCustomer();
                }
                if(input == 4)
                {
                    System.Console.Clear();
                    status = false;
                    Login.mainLogin();
                }
                if(input == 4)
                {
                    Environment.Exit(-1);
                }

            } while(status);
        }
    }
}