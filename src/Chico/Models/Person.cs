using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Person
    {
        public Person()
        {
            Organization = new HashSet<Organization>();
            OrgPerson = new HashSet<OrgPerson>();
        }

        public long PartyId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseDateOfBirth { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<OrgPerson> OrgPerson { get; set; }
        public virtual Party Party { get; set; }
    }
}
