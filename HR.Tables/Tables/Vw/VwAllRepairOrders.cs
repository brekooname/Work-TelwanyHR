using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwAllRepairOrders
    {
        public int RepairId { get; set; }
        public int? TrNo { get; set; }
        public string DocTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string ManualTrNo { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public bool? DefualtCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
    }
}
