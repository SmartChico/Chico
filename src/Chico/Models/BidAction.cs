using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class BidAction
    {
        public int BidId { get; set; }
        public long PartyId { get; set; }
        public int ActionId { get; set; }
        public DateTime ActionDate { get; set; }

        public virtual Action Action { get; set; }
        public virtual Bid Bid { get; set; }
        public virtual Party Party { get; set; }
    }
}
