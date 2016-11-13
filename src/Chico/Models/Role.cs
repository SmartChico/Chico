using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Role
    {
        public Role()
        {
            ProjectParty = new HashSet<ProjectParty>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProjectParty> ProjectParty { get; set; }
    }
}
