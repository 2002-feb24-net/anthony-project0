using System;
using System.Linq;

namespace BalloonParty.ConsoleApp.Logic
{
    public class StoreData
    {

        // Adds Store to Database
        public static void AddStore()
        {
            bool status = true;
            do{
                System.Console.WriteLine("Please Enter Your Store Name");
                string storeName = Console.ReadLine();
                System.Console.WriteLine("Please Enter Your Store Street Address");
                string storeAddress = Console.ReadLine();
                System.Console.WriteLine("Please Enter The City");
                string storeCity = Console.ReadLine();
                System.Console.WriteLine("Please Enter The State");
                string storeState = Console.ReadLine();
                System.Console.WriteLine("Please Enter The Zip Code");
                int storeZipCode = int.Parse(Console.ReadLine()); 


                using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
                {
                    var newStore = new BalloonParty.Data.Entities.Store{
                        StoreName = storeName,
                        Address = storeAddress,
                        City = storeCity,
                        State = storeState,
                        ZipCode = storeZipCode,
                    
                    };

                    context.Store.Add(newStore);
                    context.SaveChanges();
                    System.Console.WriteLine($"Store : {storeName} has been added");
                    System.Console.WriteLine("Would you like to add another store y/n");
                    string x = Console.ReadLine();
                    if(x == "n")
                    {
                        ShowStores();
                        status = false;
                        Environment.Exit(-1);
                        //BalloonParty.ConsoleApp.Program.RunUIOptions();
                    }
                }   

            } while(status);
        }

        // Shows List of store locations
        public static void ShowStores()
        {
            using (var context = new BalloonParty.Data.Entities.BalloonPartyContext())
            {
                var data = context.Store.ToList();
                int i = 1;
                foreach(var item in data)
                {
                    System.Console.WriteLine($"{item.StoreId}. {item.StoreName} : {item.Address} {item.City} {item.State} {item.ZipCode}");
                    i++;
                }
            }
        }
    }
}