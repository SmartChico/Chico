using System;
using System.Collections.Generic;

namespace Chico.Models
{
    public partial class FinancialInfo
    {
        public string FinancialInfoId { get; set; }
        public long? AccountingFirm { get; set; }
        public long? ChiefAccountant { get; set; }
        public string AccountingSoftware { get; set; }
        public string EstimateSoftware { get; set; }
        public string JobCostSoftware { get; set; }
        public string FinancialStatementBasis { get; set; }
        public string FinancialStatementIssuePeriod { get; set; }
        public long BankId { get; set; }
        public string TaxId { get; set; }
        public string Ssn { get; set; }
        public string LargestBondValue { get; set; }
        public string PercentageSubcontracted { get; set; }
        public string LeasedEquipment { get; set; }
        public string BankruptcyDescription { get; set; }
        public string LargestBacklog { get; set; }

        public virtual Organization Bank { get; set; }
    }
}
