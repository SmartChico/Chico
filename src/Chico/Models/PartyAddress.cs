using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyAddress
    {
        public long PartyId { get; set; }
        public long AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Party Party { get; set; }
    }
}
