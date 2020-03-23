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
            StoreLocation = new HashSet<StoreLocation>();
        }

        public string StoreName { get; set; }
        public int StoreId { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<StoreLocation> StoreLocation { get; set; }
    }
}
