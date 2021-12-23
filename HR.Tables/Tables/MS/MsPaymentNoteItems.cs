using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPaymentNoteItems
    {
        public int PayItemsId { get; set; }
        public int? PayId { get; set; }
        public int? ItemCardId { get; set; }
        public decimal? Price { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitRate { get; set; }
        public byte? ItemType { get; set; }
        public string BarCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QtyBeforRate { get; set; }
        public decimal? ExecutedQty { get; set; }
        public decimal? PriceAfterRate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string ItemCardDesc { get; set; }
        public string ItemCardDescE { get; set; }
        public string Remarks { get; set; }
        public string Remarks2 { get; set; }
        public bool? ShipExecuted { get; set; }

        public virtual MsPaymentNote Pay { get; set; }
    }
}
