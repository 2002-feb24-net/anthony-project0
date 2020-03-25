using System;

namespace BalloonParty.ConsoleApp
{
    public class CustomerData
    {
        
        // Adds Customer To Database
        public static void AddCustomer()
        {
            bool status = true;

            do{
                System.Console.WriteLine("Please Enter Your First Name");
            string firstName = Console.ReadLine();

            System.Console.WriteLine("Please Enter Your Last Name");
            string lastName = Console.ReadLine();

            System.Console.WriteLine("Please Enter Your Email Address");
            string emailAddress = Console.ReadLine();

            System.Console.WriteLine("Please Enter Your Street Address (With Street Name)");
            string streetAddress = Console.ReadLine();

            System.Console.WriteLine("Please Enter The City You Live In");
            string cityName = Console.ReadLine();

            System.Console.WriteLine("Please Enter The State You Live In");
            string stateName = Console.ReadLine();

            System.Console.WriteLine("Please Enter Your Zip Code");
            int zipCode = int.Parse(Console.ReadLine());

            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var newCustomer = new BalloonParty.Data.Entities.Customer{
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
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
                    BalloonParty.ConsoleApp.Program.RunUIOptions();
                }
            }
            }while(status);

        }
    }
}