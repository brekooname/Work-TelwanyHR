using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVwItemBatchStores
    {
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public int StoreId { get; set; }
        public int ItemCardId { get; set; }
        public int ItemAtrribBatchId { get; set; }
    }
}
