using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwGetDeliverSalesInvoiceByCust
    {
        public string DocTrNo { get; set; }
        public string PrefixCode { get; set; }
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalCostAverage { get; set; }
        public decimal? TotalLastCost { get; set; }
        public string IsCust { get; set; }
        public int DeliverId { get; set; }
        public int? BookId { get; set; }
        public int? StoreId { get; set; }
    }
}
