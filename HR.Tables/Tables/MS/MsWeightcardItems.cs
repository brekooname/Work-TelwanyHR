using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsWeightcardItems
    {
        public int WeightItemId { get; set; }
        public int? ScaleCardId { get; set; }
        public int? ItemCardId { get; set; }
        public int? LotNumberExpiryId { get; set; }
        public int? ItemAtrribBatchId { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitRate { get; set; }
        public string BarCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QtyBeforRate { get; set; }
        public decimal? ScaleQuantity { get; set; }
        public decimal? ScaleQtyBeforRate { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual MsWeightCard ScaleCard { get; set; }
    }
}
