using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVwItemBatchesQtyInStores
    {
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public string PartCode { get; set; }
        public string PartDescA { get; set; }
        public int? ItemCardId { get; set; }
        public decimal? QtyPartiation { get; set; }
        public decimal? QtyInNotebook { get; set; }
        public int StoreId { get; set; }
        public int StorePartId { get; set; }
        public int ItemAtrribBatchId { get; set; }
        public string ItemBatchCode { get; set; }
        public string ItemBatchName1 { get; set; }
    }
}
