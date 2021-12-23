using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class AssetAssetSettingDetails
    {
        public int AssetSetDetails { get; set; }
        public int? AssetSetId { get; set; }
        public int? AssetId { get; set; }
        public DateTime? DeprStartDate { get; set; }
        public decimal? UsablifeTime { get; set; }
        public decimal? ScrapValu { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }

        public virtual AssetAssetSettings AssetSet { get; set; }
    }
}
