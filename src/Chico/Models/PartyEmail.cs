using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyEmail
    {
        public long PartyId { get; set; }
        public long EmailId { get; set; }

        public virtual Email Email { get; set; }
        public virtual Party Party { get; set; }
    }
}
