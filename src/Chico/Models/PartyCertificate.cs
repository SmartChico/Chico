using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyCertificate
    {
        public long PartyId { get; set; }
        public int CertificateId { get; set; }
        public string Comments { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Party Party { get; set; }
    }
}
