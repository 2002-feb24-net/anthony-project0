using System;
using System.Collections.Generic;

namespace BalloonParty.Data.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public string EmailAddress { get; set; }
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public int InvoiceId { get; set; }

        public virtual Customer EmailAddressNavigation { get; set; }
        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
