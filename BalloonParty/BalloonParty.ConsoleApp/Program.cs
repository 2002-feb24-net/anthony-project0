using System;
using BalloonParty.ConsoleApp.Logic;


namespace BalloonParty.ConsoleApp
{
    class Program
    {

        // MAIN PROGRAM RUN
        static void Main(string[] args)
        {
            System.Console.Clear();
            //RunUIOptions();
            //userInterface.userMainMenu();
            Login.mainLogin();
        }

        // public static void RunUIOptions()
        // {
        //     int userOption = BalloonParty.ConsoleApp.userMenu.MenuInterface();
        //     if(userOption == 1)
        //     {
        //         BalloonParty.ConsoleApp.CustomerData.AddCustomer(); //adds customer to database
        //     }
        //     if(userOption == 2)
        //     {
        //         BalloonParty.ConsoleApp.StoreData.AddStore(); // adds store to database
        //     }
        //     if(userOption == 3)
        //     {
        //         BalloonParty.ConsoleApp.ProductData.AddProduct(); // adds store to database
        //     }
        //     if(userOption == 4)
        //     {
        //         //BalloonParty.ConsoleApp.ProductData.ShowInventory(); // adds store to database
        //     }
        //     if(userOption == 5)
        //     {
        //         System.Console.WriteLine("This Option is Currently Not Available\n");; // returns to main menu
        //         RunUIOptions();
        //     }
        //     if(userOption == 6)
        //     {
        //         BalloonParty.ConsoleApp.StoreData.ShowStore(); // adds store to database
        //     }
        // }

    }
}
