using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Bid
    {
        public Bid()
        {
            BidAction = new HashSet<BidAction>();
        }

        public int BidId { get; set; }
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public long OwnerId { get; set; }
        public long? WinnerId { get; set; }
        public string Summary { get; set; }
        public double? TotalValue { get; set; }
        public int? Currency { get; set; }

        public virtual ICollection<BidAction> BidAction { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual Party Owner { get; set; }
        public virtual Project Project { get; set; }
        public virtual Party Winner { get; set; }
    }
}
