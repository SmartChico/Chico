using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Action
    {
        public Action()
        {
            BidAction = new HashSet<BidAction>();
        }

        public int ActionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BidAction> BidAction { get; set; }
    }
}
