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
                System.Console.WriteLine("Please select the coorisponding number of your task\n1: Add Customer\n2: Order New Items\n3: Return to Login\n4: Exit Application");
                int input = int.Parse(Console.ReadLine());
                
                if(input == 1)
                {
                    System.Console.Clear();
                    status = false;
                    CustomerData.AddCustomer();
                }
                if(input == 2)
                {
                    System.Console.Clear();
                    status = false;
                    ProductData.OrderProducts();
                }
                if(input == 3)
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