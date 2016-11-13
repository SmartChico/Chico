using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class ProjectEventType
    {
        public ProjectEventType()
        {
            Event = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
