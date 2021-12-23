using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwItemUnitSummary
    {
        public int UnitId { get; set; }
        public int? ItemCardId { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? ItemUnitRate { get; set; }
        public bool? IsDefaultSale { get; set; }
        public bool? IsDefaultPurchas { get; set; }
        public decimal? CoastAverage { get; set; }
        public string UnitCode { get; set; }
        public string UnitNam { get; set; }
        public string Symbol { get; set; }
        public decimal? LastCost { get; set; }
        public decimal? BeforLastCost { get; set; }
    }
}
