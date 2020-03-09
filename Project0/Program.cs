/*
Author: Anthony Harrington
Date: March 2020
Project: Project 0
Status: Building Phase

Project Info
- place orders to store locations for customers
- add a new customer
- search customers by name
- display details of an order
- display all order history of a store location
- display all order history of a customer
- input validation
- (optional: order history can be sorted by earliest, latest, cheapest, most expensive)
- (optional: get a suggested order for a customer based on his order history)
- (optional: display some statistics based on order history)

*/
using System;
using Excel = Microsoft.CSharp.RuntimeBinder;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person("Bob", "Doe", 123456);
            var product1 = new Product("Lysol", 16354);
            System.Console.WriteLine(person1.ToString());
            System.Console.WriteLine(product1.ToString());
            
        }
    }
}
