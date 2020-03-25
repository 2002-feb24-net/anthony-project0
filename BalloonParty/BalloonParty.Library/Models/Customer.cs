namespace BalloonParty.Library.Models
{
    public class Customer
    {
        string firstName {get; set;}
        string lastName{get; set;}
        string emailAddress {get; set;}
        string address {get; set;}
        string city {get; set;}
        string state {get; set;}
        int zipCode {get; set;}


        public Customer(string firstName, string lastName, string emailAddress, string address, string city, string state, int zipCode)
        {
            firstName = this.firstName;
            lastName = this.lastName;
            emailAddress = this.emailAddress;
            address = this.address;
            city = this.city;
            state = this.state;
            zipCode = this.zipCode;
        }
    }

    
}