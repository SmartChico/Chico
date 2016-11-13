using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class PartyLicense
    {
        public long PartyId { get; set; }
        public int LicenseId { get; set; }
        public string Comments { get; set; }

        public virtual License License { get; set; }
        public virtual Party Party { get; set; }
    }
}
