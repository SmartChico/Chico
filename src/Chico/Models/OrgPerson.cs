using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class OrgPerson
    {
        public long PersonId { get; set; }
        public long OrgId { get; set; }
        public int OrgRoleId { get; set; }
        public int? SharesOwned { get; set; }
        public DateTime AffiliationStartDate { get; set; }

        public virtual Organization Org { get; set; }
        public virtual OrganizationRole OrgRole { get; set; }
        public virtual Person Person { get; set; }
    }
}
