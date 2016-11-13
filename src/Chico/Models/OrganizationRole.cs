using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class OrganizationRole
    {
        public OrganizationRole()
        {
            OrgPerson = new HashSet<OrgPerson>();
        }

        public int OrgRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrgPerson> OrgPerson { get; set; }
    }
}
