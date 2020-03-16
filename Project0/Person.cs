/*
Author: Anthony Harrington
Date: March 2020
Project: Project 0
*/

using System;
using System.Collections.Generic;

namespace Project0
{
    class Person
    {

        /// fields
        public string firstName {get; set;}
        public string lastName {get; set;}
        public int userID {get; set;}


        // list creation for serialization
        public List<Person> NewUserInfo { get; set; } = new List<Person>();


        // Constructor
        public Person(string firstName, string lastName, int userID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userID = userID;
            AddFirstName();
            AddLastName();
            AddUserID();
        }


        // used to return user data
        public override string ToString()
        {        
            return $"User Info : {firstName} {lastName} : ID = {userID}";
        }


        // method to get users first name
        private string AddFirstName()
        {
            Console.WriteLine("Please your first name");
            string firstName = Console.ReadLine();
            return firstName;
        }


        // method used to get users last name
        private string AddLastName()
        {
            Console.WriteLine("Please Enter Your Last Name");
            string lastName = Console.ReadLine();
            return lastName;
        }


        // will check database and add an ID to the users account, ID will be a number not yet assigned
        private int AddUserID()
        {
            return userID;
        }
    }
}