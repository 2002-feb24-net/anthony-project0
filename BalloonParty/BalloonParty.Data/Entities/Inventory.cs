using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class Inventory
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public int ItemCount { get; set; }
        public int InventoryId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
