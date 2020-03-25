using System;
using System.Linq;

namespace BalloonParty.ConsoleApp
{
    public class ProductData
    {
        
        public static void AddProduct()
        {
            bool status = true;
            do{
                System.Console.WriteLine("Please Enter The Product Name");
                string itemName = Console.ReadLine();
                System.Console.WriteLine("Please Enter The Product Price (ex. 1.99 or 10.99)");
                decimal itemPrice = Convert.ToDecimal(Console.ReadLine());
                System.Console.WriteLine("Please Enter The Product Quantity");
                int itemAmount = int.Parse(Console.ReadLine());

                


                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    var newItem = new BalloonParty.Data.Entities.Item{
                        ItemName = itemName,
                        Price = itemPrice,
                        Quantity = itemAmount,
                    
                    };

                    context.Item.Add(newItem);
                    context.SaveChanges();
                    System.Console.WriteLine($"Item : {itemName} has been added");
                    System.Console.WriteLine("Would you like to add another store y/n");
                    string x = Console.ReadLine();
                    if(x == "n")
                    {
                        status = false;
                        BalloonParty.ConsoleApp.Program.RunUIOptions();
                    }
                }   

            } while(status);
        }

        public static void ShowInventory()
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.Item.ToList();
                int i = 1;
                foreach(var item in data)
                {
                    System.Console.WriteLine($"{i}. {item.ItemName} : Price: ${item.Price} - Amount Left {item.Quantity}");
                    i++;
                }
            }

            System.Console.WriteLine("Would you like to place an order (y/n), if no you will be returned to the main menu.");
            string userAnswer = Console.ReadLine();
            if(userAnswer == "y")
            {
                CustomerOrder();
            }
            else if(userAnswer == "n")
            {
                BalloonParty.ConsoleApp.Program.RunUIOptions();
            }
        }

        //  creates an invoice order
        public static void CustomerOrder()
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.Item.ToList();
                int i = 1;
                foreach(var item in data)
                {
                    System.Console.WriteLine($"{i}. {item.ItemName} : Price: ${item.Price} - Amount Left {item.Quantity}");
                    i++;
                }

                System.Console.WriteLine("Please select the corresponding number of the item you would like to purchase");
                int userInput = int.Parse(Console.ReadLine());
                if(userInput == 1)
                {
                    var item = context.Item.First();
                    System.Console.WriteLine($"Selected Product {item.ItemName} : Price: ${item.Price}");
                    System.Console.WriteLine($"Please enter the ammount you would like to purchase (Quanity Left {item.Quantity}");
                    int purchasedAmount = int.Parse(Console.ReadLine());

                    decimal totalPrice = item.Price * purchasedAmount;

                    var newOrder = new BalloonParty.Data.Entities.Invoice{
                        EmailAddress = "customer@outlook.com",
                        StoreId = 1,
                        ItemId = item.ItemId,
                        ItemCount = purchasedAmount,
                    };

                    System.Console.WriteLine($"\nUser: {newOrder.EmailAddress}\nStore ID: {newOrder.StoreId}\nProduct: {item.ItemName}\nTotal Price: {totalPrice}");
                    context.Invoice.Add(newOrder);
                    context.SaveChanges();
                }
            }
        }
    }
}