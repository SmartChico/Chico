using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Party
    {
        public Party()
        {
            BidOwner = new HashSet<Bid>();
            BidWinner = new HashSet<Bid>();
            BidAction = new HashSet<BidAction>();
            PartyAddress = new HashSet<PartyAddress>();
            PartyCertificate = new HashSet<PartyCertificate>();
            PartyEmail = new HashSet<PartyEmail>();
            PartyLicense = new HashSet<PartyLicense>();
            PartyPhone = new HashSet<PartyPhone>();
            PartyUserAccount = new HashSet<PartyUserAccount>();
            ProjectPartyOverseeingParty = new HashSet<ProjectParty>();
            ProjectPartyParty = new HashSet<ProjectParty>();
        }

        public long PartyId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModfiedDate { get; set; }

        public virtual ICollection<Bid> BidOwner { get; set; }
        public virtual ICollection<Bid> BidWinner { get; set; }
        public virtual ICollection<BidAction> BidAction { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<PartyAddress> PartyAddress { get; set; }
        public virtual ICollection<PartyCertificate> PartyCertificate { get; set; }
        public virtual ICollection<PartyEmail> PartyEmail { get; set; }
        public virtual ICollection<PartyLicense> PartyLicense { get; set; }
        public virtual ICollection<PartyPhone> PartyPhone { get; set; }
        public virtual ICollection<PartyUserAccount> PartyUserAccount { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<ProjectParty> ProjectPartyOverseeingParty { get; set; }
        public virtual ICollection<ProjectParty> ProjectPartyParty { get; set; }
    }
}
