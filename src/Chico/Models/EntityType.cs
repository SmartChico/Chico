using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class EntityType
    {
        public EntityType()
        {
            Organization = new HashSet<Organization>();
        }

        public int EntityTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
