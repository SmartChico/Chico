using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Naics
    {
        public Naics()
        {
            Organization = new HashSet<Organization>();
        }

        public int TypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
