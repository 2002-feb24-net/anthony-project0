using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class CustomerOrder
    {
        public string CustomerEmail { get; set; }
        public int CustomerLine { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public int CustomerOrderId { get; set; }

        public virtual Customer CustomerEmailNavigation { get; set; }
        public virtual Invoice CustomerLineNavigation { get; set; }
    }
}
