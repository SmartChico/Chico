using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class ProjectParty
    {
        public int ProjectId { get; set; }
        public long PartyId { get; set; }
        public int PartyRoleInProject { get; set; }
        public DateTime AssignmentDate { get; set; }
        public long? OverseeingPartyId { get; set; }

        public virtual Party OverseeingParty { get; set; }
        public virtual Party Party { get; set; }
        public virtual Role PartyRoleInProjectNavigation { get; set; }
        public virtual Project Project { get; set; }
    }
}
