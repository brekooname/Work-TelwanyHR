using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class AssetAssetMoveDocDetail
    {
        public int AssetMovDetailId { get; set; }
        public int? AssetMovId { get; set; }
        public int? AssetId { get; set; }
        public int? OldStoreId { get; set; }
        public int? NewStoreId { get; set; }
        public int? OldDepartMentId { get; set; }
        public int? NewDepartMentId { get; set; }
        public decimal? MoveCost { get; set; }

        public virtual AssetAssetMoveDoc AssetMov { get; set; }
    }
}
