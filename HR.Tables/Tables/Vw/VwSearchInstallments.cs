using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwSearchInstallments
    {
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string CustomerDescE { get; set; }
        public int Cc { get; set; }
        public string DocTrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public int? ContractTrNo { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PayStartDate { get; set; }
        public decimal? ActualSalesPrice { get; set; }
        public bool? PaidInCash { get; set; }
        public bool? IsContract { get; set; }
    }
}
