using System;
using System.Linq;

namespace BalloonParty.ConsoleApp.Logic
{

    public class Login
    {
        // Main Login Screen ******************************
        public static void mainLogin()
        {
            bool status = true;
            int newInput = 0;
            do{
                System.Console.WriteLine("Please select if you are a customer, a store, or an admin\n1: Customer\n2: Store\n3: Admin");
                string input = Console.ReadLine();
                if(input == "1" || input == "2" || input == "3")
                {
                    try
                    {
                        newInput  = int.Parse(input);
                        status = false;
                    }
                    catch (System.Exception)
                    {
                        
                        System.Console.WriteLine("Invalid input, please try again");
                    }
                    
                }
                
                
            }while(status);
            System.Console.WriteLine("Please select if you are a customer, a store, or an admin or press zero to exit.\n1: Customer\n2: Store\n3: Admin\n\n0: Exit");

            // int input;
            // while (!int.TryParse(Console.ReadLine(), out input))
            // {
            //     Console.WriteLine("Invalid input. Try again");
            // }

            if(newInput == 0)
            {
                Environment.Exit(-1);
            }
            System.Console.WriteLine("\nPLEASE LOGIN");
            System.Console.WriteLine("Please Enter Your Login ID");
            string email = Console.ReadLine();
            System.Console.WriteLine("\nPlease Enter Your Password");
            string pw = Console.ReadLine();
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                try
                {
                    if(newInput == 1)
                    {
                        var users = context.Customer.First(c=> c.EmailAddress == email && c.CustomerPw == pw);
                        System.Console.Clear();
                        userInterface.userMainMenu();
                    }
                    if(newInput == 2)
                    {
                        var storeUser = context.Store.First(s=> s.StoreUsername == email && s.StorePw == pw);
                        System.Console.Clear();
                        storeInterface.storeMainMenu();
                    }
                    if(newInput == 3)
                    {
                        var rootuser = context.RootUser.First(r => r.RootName == email && r.RootPw == pw);
                        System.Console.Clear();
                        adminInterface.adminMainMenu();
                    }



                }
                catch (Exception)
                {

                    System.Console.WriteLine("Invalid Login\n\n");
                    System.Console.Clear();
                    mainLogin();
                }
            }
        }
    }
}
