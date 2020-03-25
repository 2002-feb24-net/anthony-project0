using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class Item
    {
        public Item()
        {
            Inventory = new HashSet<Inventory>();
            Invoice = new HashSet<Invoice>();
        }

        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
