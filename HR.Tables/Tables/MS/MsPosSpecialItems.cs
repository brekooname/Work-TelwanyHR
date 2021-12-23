using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPosSpecialItems
    {
        public int SpecialItemCardId { get; set; }
        public int? ItemCardId { get; set; }
        public int? ItemAtrribBatchId { get; set; }
        public byte? ItemType { get; set; }
        public string BarCode { get; set; }
        public int? UnitId { get; set; }
        public decimal? Price { get; set; }
        public bool? IsBonus { get; set; }
        public bool? IsCollection { get; set; }
        public string Remarks { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string ItemCardDesc { get; set; }
        public string ItemCardDescE { get; set; }
    }
}
