using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            PartyUserAccount = new HashSet<PartyUserAccount>();
        }

        public long AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Verified { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModfiedDate { get; set; }

        public virtual ICollection<PartyUserAccount> PartyUserAccount { get; set; }
    }
}
