using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class Store
    {
        // fileds
        string storeName { get; set; }
        int storeID { get; set; }


        // Constructor
        public Store(string storeName, int storeID)
        {
            this.storeName = storeName;
            this.storeID = storeID;
        }


        // Method to return store information
        public override string ToString()
        {
            return $"User Info : {storeName} : ID = {storeID}";
        }


        // method to get store name
        private string AddStoreName()
        {
            Console.WriteLine("Please Enter Your Store Name");
            string storeName = Console.ReadLine();
            return storeName;
        }

        // this will get an ID from the database and add it to the store
        private int AddStoreID()
        {
            return storeID;
        }
    }
}
