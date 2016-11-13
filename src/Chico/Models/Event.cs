using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Event
    {
        public long EventId { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public int? ProjectId { get; set; }
        public string Comments { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectEventType TypeNavigation { get; set; }
    }
}
