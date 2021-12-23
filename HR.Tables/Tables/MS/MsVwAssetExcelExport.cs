using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVwAssetExcelExport
    {
        public string AssetCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public bool? IsProduction { get; set; }
        public int? RemainInstallments { get; set; }
        public int? InstallMentCount { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string CatCode { get; set; }
        public string CatDescA { get; set; }
    }
}
