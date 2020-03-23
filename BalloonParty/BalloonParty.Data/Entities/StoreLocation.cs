using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class StoreLocation
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int StoreId { get; set; }
        public int LocationId { get; set; }

        public virtual Store Store { get; set; }
    }
}
