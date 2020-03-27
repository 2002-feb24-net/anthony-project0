using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class StoreInventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int SinventoryId { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual Products Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
