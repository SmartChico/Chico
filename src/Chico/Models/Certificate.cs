using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class Certificate
    {
        public Certificate()
        {
            PartyCertificate = new HashSet<PartyCertificate>();
        }

        public int CertificateId { get; set; }
        public string Name { get; set; }
        public long IssuingBodyId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PartyCertificate> PartyCertificate { get; set; }
        public virtual Organization IssuingBody { get; set; }
    }
}
