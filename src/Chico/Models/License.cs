using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class License
    {
        public License()
        {
            PartyLicense = new HashSet<PartyLicense>();
        }

        public int LicenseId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? IssuingOrgId { get; set; }

        public virtual ICollection<PartyLicense> PartyLicense { get; set; }
        public virtual Organization IssuingOrg { get; set; }
    }
}
