using System;
using System.Linq;

namespace BalloonParty.ConsoleApp.Logic
{
    public class ProductData
    {
        // Adds Products to Database
        public static void AddProduct()
        {
            bool status = true;
            do{
                System.Console.WriteLine("Please Enter The Product Name");
                string productName = Console.ReadLine();
                System.Console.WriteLine("Please Enter The Product Price (ex. 1.99 or 10.99)");
                decimal productPrice = Convert.ToDecimal(Console.ReadLine());

                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    var newProduct = new BalloonParty.Data.Entities.Products{
                        ProductName = productName,
                        ProductPrice = productPrice,
                    
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    System.Console.WriteLine($"Product : {newProduct} has been added\n\n");
                    System.Console.WriteLine("Would you like to add another product y/n");
                    string x = Console.ReadLine();
                    if(x == "n")
                    {
                        status = false;
                        adminInterface.adminMainMenu();
                    }
                }
                System.Console.Clear();  

            } while(status);
        }

        // Shows the inventory of a specific store (not working)
        public static void ShowInventory(int input)
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.StoreInventory.Where(i=> i.StoreId == input).ToList();
                foreach(var x in data)
                {
                    System.Console.WriteLine($"{x.ProductId} : {x.ProductName}");
                }
                System.Console.WriteLine("Please select the corresponding number of the item you would like to purchase");
                //var data2 = context.StoreInventory.Where(p=> p.ProductId)
            }
        }

        // Shows alll products in the products table
        public static void ShowProducts()
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.Products.ToList();
                int i = 1;
                foreach(var item in data)
                {
                    System.Console.WriteLine($"{item.ProductId} : {item.ProductName}");
                    i++;
                }
            }
        }

        // This allows a store to order products for their store from the warehouse
        public static void OrderProducts()
        {
            StoreData.ShowStores();
            System.Console.WriteLine("Please enter your Store Number");
            int storeID = int.Parse(Console.ReadLine());
            System.Console.Clear();
            ShowProducts();
            bool status = true;
            do{
                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    System.Console.WriteLine("Please enter the cooresponding number of the item you would like to order");
                    int input = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Plese enter the ammount you would like in your inventory");
                    int amount = int.Parse(Console.ReadLine());

                    string pName = context.Products.First(p=> p.ProductId == input).ProductName;
                    int pID = context.Products.First(p=> p.ProductId == input).ProductId;
                    int sID = context.Store.First(s=> s.StoreId == input).StoreId;

                    var addProduct = new BalloonParty.Data.Entities.StoreInventory{
                        StoreId = sID,
                        ProductId = pID,
                        ProductName = pName,
                        ProductCount = amount,
                    };
                    context.StoreInventory.Add(addProduct);
                    context.SaveChanges();
                    System.Console.WriteLine("Would You Like to Add More Product to Your Store  y/n");
                    string answer = Console.ReadLine();
                    if(answer == "n")
                    {
                        System.Console.Clear();
                        status = false;
                        storeInterface.storeMainMenu();
                    }
                    System.Console.Clear();
                }
            }while(status);    
        }
    }
}