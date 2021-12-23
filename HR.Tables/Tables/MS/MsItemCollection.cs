using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsItemCollection
    {
        public int ItemCollectId { get; set; }
        public int? ItemCardId { get; set; }
        public int? SubItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitRate { get; set; }
        public byte? ItemType { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QtyBeforRate { get; set; }
        public string Remarks { get; set; }

        public virtual MsItemCard ItemCard { get; set; }
    }
}
