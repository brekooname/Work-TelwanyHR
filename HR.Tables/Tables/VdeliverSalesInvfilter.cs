using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VdeliverSalesInvfilter
    {
        public int? StoreId { get; set; }
        public int TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public int InvTrNo { get; set; }
        public decimal? DeliverQtyOut { get; set; }
        public string StrCustm4 { get; set; }
        public string StrCustm5 { get; set; }
    }
}
