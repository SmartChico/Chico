using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Address
    {
        public Address()
        {
            PartyAddress = new HashSet<PartyAddress>();
        }

        public long AddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Apt { get; set; }
        public string Zip { get; set; }
        public string PostlCode { get; set; }
        public string WebAddress { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PartyAddress> PartyAddress { get; set; }
    }
}
