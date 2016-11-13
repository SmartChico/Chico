using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Phone
    {
        public Phone()
        {
            PartyPhone = new HashSet<PartyPhone>();
        }

        public long PhoneNumberId { get; set; }
        public string PhoneNumberType { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PartyPhone> PartyPhone { get; set; }
    }
}
