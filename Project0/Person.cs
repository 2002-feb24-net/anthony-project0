/*
Author: Anthony Harrington
Date: March 2020
Project: Project 0
*/

using System;

namespace Project0
{
    class Person
    {

        /// fields
        
        public string firstName {get; set;}
        public string lastName {get; set;}
        public int userID {get; set;}

        // Constructor
        public Person(string firstName, string lastName, int userID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userID = userID;
        }

        public override string ToString()
        {        
            return $"User Info : {firstName} {lastName} : ID = {userID}";
        }
    }
}