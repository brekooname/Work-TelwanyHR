using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsItemStartQty
    {
        public int StartQtyId { get; set; }
        public int? ItemCardId { get; set; }
        public int? StoreId { get; set; }
        public int? StorePartId { get; set; }
        public int? ItemAtrribBatchId { get; set; }
        public int? ItemPatchPartitionId { get; set; }
        public int? ItemPartId { get; set; }
        public decimal? QtyPartiation { get; set; }
        public decimal? QtyInNotebook { get; set; }

        public virtual MsItemCard ItemCard { get; set; }
    }
}
