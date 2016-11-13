using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Bond
    {
        public long BondRequester { get; set; }
        public long SuretyAgent { get; set; }
        public long SuretyUnderwriter { get; set; }
        public int SuretyProgramId { get; set; }
        public string DecisionStatus { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual SuretyProgram SuretyProgram { get; set; }
    }
}
