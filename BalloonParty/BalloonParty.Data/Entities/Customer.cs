using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrders>();
            ProductsPurchased = new HashSet<ProductsPurchased>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerPw { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<CustomerOrders> CustomerOrders { get; set; }
        public virtual ICollection<ProductsPurchased> ProductsPurchased { get; set; }
    }
}
