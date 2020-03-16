/*
Author: Anthony Harrington
Date: March 2020
Project: Project 0
*/

using System;

namespace Project0
{
    class Product
    {
        // fields
        public string itemName { get; set; }
        public int itemAmmount { get; set; }
        public int itemID { get; set; }


        // Construtor
        public Product(string itemName, int itemID, int itemAmmount)
        {
            this.itemName = itemName;
            this.itemID = itemID;
            this.itemAmmount = itemAmmount;
        }


        // used to return user information
        public override string ToString()
        {        
            return $"Product Info : {itemName} : ID = {itemID}";
        }


        // method used to get an Item name to add to inventory at the store
        private string AddItemName()
        {
            Console.WriteLine("Please Enter An Item Name");
            string itemName = Console.ReadLine();
            return itemName;
        }


        // method used to add item count from item in the inventory
        private int  AddItemAmmount()
        {
            Console.WriteLine("Please Enter An Item Name");
            int itemName = Int32.Parse(Console.ReadLine());
            return itemName;
        }


        // method to add an ID to the item, ID will be provided by the database 
        private int AddItemID()
        {
            return itemID;
        }
    }
}