using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chico.Models
{
    public partial class Bid
    {
        public int BidId { get; set; }
        public long OrganizationId { get; set; }
        public int ProjectId { get; set; }
        public string Summary { get; set; }
        public double? CostEstimate { get; set; }
        public int? Currency { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Role { get; set; }

        [Column(TypeName = "xml")]
        public string bidxml { get; set; }

        public virtual Currency CurrencyNavigation { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Project Project { get; set; }
    }
}
