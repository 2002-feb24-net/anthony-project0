using System;

namespace BalloonParty.ConsoleApp.Logic
{
    public class CustomerData
    {
        
        // Adds Customer To Database
        public static void AddCustomer()
        {
            bool status = true;

            do{
                System.Console.WriteLine("\n\nPlease Enter Your Information\n");
                System.Console.WriteLine("First Name");
                string firstName = Console.ReadLine();

                System.Console.WriteLine("Last Name");
                string lastName = Console.ReadLine();

                System.Console.WriteLine("Email Address");
                string emailAddress = Console.ReadLine();

                System.Console.WriteLine("Password");
                string pw = Console.ReadLine();

                System.Console.WriteLine("Street Address (With Street Name)");
                string streetAddress = Console.ReadLine();

                System.Console.WriteLine("City");
                string cityName = Console.ReadLine();

                System.Console.WriteLine("State");
                string stateName = Console.ReadLine();

                System.Console.WriteLine("Zip Code");
                int zipCode = int.Parse(Console.ReadLine());

            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var newCustomer = new BalloonParty.Data.Entities.Customer{
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    CustomerPw = pw,
                    Address = streetAddress,
                    City = cityName,
                    State = stateName,
                    ZipCode = zipCode,
                };

                context.Customer.Add(newCustomer);
                context.SaveChanges();
                System.Console.WriteLine($"Customer : {firstName} {lastName} has been stored to the database\n\n Returning to main menu");
                System.Console.WriteLine("Would you like to add another customer y/n");
                string x = Console.ReadLine();
                if(x == "n")
                {
                    status = false;
                    //BalloonParty.ConsoleApp.Program.RunUIOptions();
                    Environment.Exit(-1);
                }
            }
            }while(status);

        }
    }
}