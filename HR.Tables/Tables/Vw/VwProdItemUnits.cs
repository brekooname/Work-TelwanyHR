using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwProdItemUnits
    {
        public int ItemCardId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public string ItemDescE { get; set; }
        public int UnitId { get; set; }
        public bool? IsDefaultSale { get; set; }
        public bool? IsDefaultPurchas { get; set; }
        public int BasUnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitNam { get; set; }
        public string UnitNameE { get; set; }
        public decimal? UnittRate { get; set; }
        public int? ParentUnit { get; set; }
        public string Symbol { get; set; }
    }
}
