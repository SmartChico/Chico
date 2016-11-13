using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Email
    {
        public Email()
        {
            PartyEmail = new HashSet<PartyEmail>();
        }

        public long EmailId { get; set; }
        public string Email1 { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PartyEmail> PartyEmail { get; set; }
    }
}
