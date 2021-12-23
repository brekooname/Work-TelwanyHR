using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwReservedQty
    {
        public decimal Quantity { get; set; }
        public decimal QuantityOut { get; set; }
        public decimal? Reserved { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string StoreDescA { get; set; }
    }
}
