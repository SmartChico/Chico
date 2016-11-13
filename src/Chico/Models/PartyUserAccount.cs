using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyUserAccount
    {
        public long PartyId { get; set; }
        public long AccountId { get; set; }

        public virtual UserAccount Account { get; set; }
        public virtual Party Party { get; set; }
    }
}
