using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class SuretyProgram
    {
        public SuretyProgram()
        {
            Bond = new HashSet<Bond>();
        }

        public int SuretyProgramId { get; set; }
        public long CreatorId { get; set; }
        public double? Value { get; set; }
        public int? CurrencyId { get; set; }

        public virtual ICollection<Bond> Bond { get; set; }
        public virtual Organization Creator { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
