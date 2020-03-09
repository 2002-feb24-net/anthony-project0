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

        public string itemName;
        public int itemID;

        public Product(string itemName, int itemID)
        {
            this.itemName = itemName;
            this.itemID = itemID;
        }

        public override string ToString()
        {        
            return $"Product Info : {itemName} : ID = {itemID}";
        }
    }
}