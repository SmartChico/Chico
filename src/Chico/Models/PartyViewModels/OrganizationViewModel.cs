using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chico.Models.PartyViewModels
{
    public class OrganizationViewModel
    {
        public OrganizationViewModel()
        {
            Emails = new HashSet<Email>();
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
        public DateTime? ChicoSignUpDate { get; set; }
        public bool IncludeInListing { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual IEnumerable<Certificate> Certificates { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual IEnumerable<License> Licenses { get; set; }
        public virtual IEnumerable<Phone> Phones { get; set; }
    }
}
