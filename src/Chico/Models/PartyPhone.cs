using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyPhone
    {
        public long PartyId { get; set; }
        public long PhoneId { get; set; }

        public virtual Party Party { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
