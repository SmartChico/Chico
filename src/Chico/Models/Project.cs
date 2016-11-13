using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Project
    {
        public Project()
        {
            Bid = new HashSet<Bid>();
            Event = new HashSet<Event>();
            ProjectParty = new HashSet<ProjectParty>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int CurrentMileStone { get; set; }
        public string Summary { get; set; }
        public int? Priority { get; set; }
        public double? TotalBudget { get; set; }
        public int? Currency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<ProjectParty> ProjectParty { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
    }
}
