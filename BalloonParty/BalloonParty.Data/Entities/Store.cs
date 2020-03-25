using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            Invoice = new HashSet<Invoice>();
        }

        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int StoreId { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
