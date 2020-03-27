using System;

namespace BalloonParty.ConsoleApp.Logic
{
    public class storeInterface
    {
        public static void storeMainMenu()
        {
            
            bool status = true;
            do
            {
                System.Console.WriteLine("Please select the coorisponding number of your task\n1: Add Customer\n2: Order New Items\n3: Exit Program");
                int input = int.Parse(Console.ReadLine());
                
                if(input == 1)
                {
                    CustomerData.AddCustomer();
                }
                if(input == 2)
                {
                    ProductData.OrderProducts();
                }
                if(input == 3)
                {
                    Environment.Exit(-1);
                }

            } while(status);
        }
    }
}