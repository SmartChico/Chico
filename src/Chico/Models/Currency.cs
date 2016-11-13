using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Bid = new HashSet<Bid>();
            Project = new HashSet<Project>();
            SuretyProgram = new HashSet<SuretyProgram>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string Acronym { get; set; }
        public double DollarConversionRate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<SuretyProgram> SuretyProgram { get; set; }
    }
}
