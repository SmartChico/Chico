using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Certificate = new HashSet<Certificate>();
            FinancialInfo = new HashSet<FinancialInfo>();
            License = new HashSet<License>();
            OrgPerson = new HashSet<OrgPerson>();
            SuretyProgram = new HashSet<SuretyProgram>();
        }

        public long PartyId { get; set; }
        public string Name { get; set; }
        public int EntityTypeId { get; set; }
        public string Naicscode { get; set; }
        public long? RegisteredAgent { get; set; }
        public bool ActiveStatus { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string Purpose { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public DateTime ChicoSignUpDate { get; set; }
        public bool IncludeInListing { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Certificate> Certificate { get; set; }
        public virtual ICollection<FinancialInfo> FinancialInfo { get; set; }
        public virtual ICollection<License> License { get; set; }
        public virtual ICollection<OrgPerson> OrgPerson { get; set; }
        public virtual ICollection<SuretyProgram> SuretyProgram { get; set; }
        public virtual EntityType EntityType { get; set; }
        public virtual Naics NaicscodeNavigation { get; set; }
        public virtual Party Party { get; set; }
    }
}
