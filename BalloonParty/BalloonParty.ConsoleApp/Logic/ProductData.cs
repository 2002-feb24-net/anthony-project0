using System;
using System.Linq;

namespace BalloonParty.ConsoleApp.Logic
{
    public class ProductData
    {
        // Adds Products to Database ****************************
        public static void AddProduct()
        {
            bool status = true;
            do{
                System.Console.WriteLine("\nPlease Enter The Product Name");
                string productName = Console.ReadLine();
                System.Console.WriteLine("\nPlease Enter The Product Price (ex. 1.99 or 10.99)");
                decimal productPrice = Convert.ToDecimal(Console.ReadLine());

                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    var newProduct = new BalloonParty.Data.Entities.Products{
                        ProductName = productName,
                        ProductPrice = productPrice,
                    
                    };
                    AddToInventory(productName);
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    System.Console.WriteLine($"Product : {newProduct} has been added\n\n");
                    System.Console.WriteLine("\nWould you like to add another product y/n");
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

        // Shows the inventory of a specific store ******************************
        public static void ShowInventory(int input)
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.StoreInventory.Where(i=> i.StoreId == input).ToList();
                foreach(var x in data)
                {
                    System.Console.WriteLine($"{x.ProductId}: {x.ProductName} : Price: ${x.ProductPrice}");
                }
            }
        }

        // Shows alll products in the products table ******************************
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

        // This allows a store to order products for their store from the warehouse ******************************
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
                    System.Console.WriteLine("\nPlease enter the cooresponding number of the item you would like to order");
                    int input = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("\nPlese enter the ammount you would like in your inventory");
                    int amount = int.Parse(Console.ReadLine());

                    string pName = context.Products.First(p=> p.ProductId == input).ProductName;
                    int pID = context.Products.First(p=> p.ProductId == input).ProductId;
                    int sID = context.Store.First(s=> s.StoreId == input).StoreId;
                    decimal pPrice = context.Products.First(pr=> pr.ProductId== input).ProductPrice;
                    var addProduct = new BalloonParty.Data.Entities.StoreInventory{
                        StoreId = sID,
                        ProductId = pID,
                        ProductName = pName,
                        ProductCount = amount,
                        ProductPrice = pPrice,
                    };
                    SubtractFromInventory(pID, amount);
                    context.StoreInventory.Add(addProduct);
                    context.SaveChanges();
                    System.Console.WriteLine("\nWould You Like to Add More Product to Your Store  y/n");
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

        public static void SubtractFromInventory(int pID, int amount)
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var inventoryObject = context.StoreInventory.First(c=> c.ProductId == pID);
                inventoryObject.ProductCount = inventoryObject.ProductCount -amount;
                context.Update(inventoryObject);
                context.SaveChanges();
            }
            
        }

        public static void AddToInventory(string productName)
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var inventoryObject = context.StoreInventory.First(c=> c.ProductName == productName);
                inventoryObject.ProductCount = inventoryObject.ProductCount +1;
                context.Update(inventoryObject);
                context.SaveChanges();
            }
            
        }
    }
}