using System;
using System.Linq;

namespace BalloonParty.ConsoleApp.Logic
{
    public class CustomerData
    {
        
        // Adds Customer To Database ******************************
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
                    storeInterface.storeMainMenu();
                }
            }
            }while(status);
        }

        // Shows Customer Orders by Customer Email ****************************
        public  static void ShowCustomersOrders()
        {
            bool status = true;
            System.Console.WriteLine("Please enter your email address");
            string cEmail = Console.ReadLine();
            try
            {
                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    var data = context.CustomerOrders.Where(e=> e.CustomerEmail == cEmail).ToList();
                    foreach(var x in data)
                    System.Console.WriteLine($"Order Number {x.CustomerOrderId} : Order Date {x.OrderDate} : Product {x.ProductName} :  Amount {x.FullProductCount} : Total Price {x.TotalPrice}");
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("You Do Not Have Any Order History");
            }
            do{
                System.Console.WriteLine("\n\n");
                System.Console.WriteLine("Press '1' to return to the main menu or '2' to exit application");
                int keyPress = int.Parse(Console.ReadLine());
                if(keyPress == 1)
                {
                    System.Console.Clear();
                    status = false;
                    userInterface.userMainMenu();
                }
                if(keyPress == 2)
                {
                    System.Console.Clear();
                    status = false;
                    Environment.Exit(-1);
                }
            }while(status);
        }

        //  Place Customer Orders
        public static void PlaceOrder()
        {
            bool status = true;
            System.Console.WriteLine("Please enter your email address");
            string cEmail = Console.ReadLine();
            do
            {
                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {               
                    StoreData.ShowStores();
                    System.Console.WriteLine("Please select the cooresponding number of the store you would like to visit");
                    int customerChoice = int.Parse(Console.ReadLine());
                    System.Console.Clear();
                    ProductData.ShowInventory(customerChoice);
                    System.Console.WriteLine("Please enter the cooresponding number of the item you would like to purchase");
                    int input = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("\nPlease Enter the quantity you would like to purchase");
                    int purchaseQuantity = int.Parse(Console.ReadLine());

                    var pPrice = context.StoreInventory.First(pp=> pp.ProductId == input).ProductPrice;
                    var pName = context.StoreInventory.First(pn=> pn.ProductId == input).ProductName;
                    var totalPrice = pPrice * purchaseQuantity;
                    var newOrder = new BalloonParty.Data.Entities.CustomerOrders{
                            CustomerEmail = cEmail,
                            FullProductCount = purchaseQuantity,
                            TotalPrice = totalPrice,
                            ProductName = pName,
                            OrderDate = DateTime.Now,
                    };
                    context.CustomerOrders.Add(newOrder);
                    context.SaveChanges();
                    System.Console.WriteLine($"\n Your order has been submitted: {pName}: Quantity {purchaseQuantity}: Total Price ${totalPrice}");
                    System.Console.WriteLine("\nWould you like to place another order from the same store, y/n , no will bring you back to the main menu");
                    string userInput = Console.ReadLine();
                    if(userInput == "n")
                    {
                        System.Console.Clear();
                        status = false;
                        userInterface.userMainMenu();
                    }
                }

            }while(status);
            
        }
    }
}