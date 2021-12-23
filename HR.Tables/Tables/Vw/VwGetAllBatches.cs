using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwGetAllBatches
    {
        public int ItemAtrribBatchId { get; set; }
        public int? ItemCardId { get; set; }
        public string ItemBatchCode { get; set; }
        public string ItemBatchName1 { get; set; }
        public string ItemBatchName2 { get; set; }
        public decimal? MultiplyValues { get; set; }
        public bool UseBatchPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? BatchLength { get; set; }
        public decimal? BatchWidth { get; set; }
        public decimal? BatchHieght { get; set; }
        public bool IsStandard { get; set; }
        public bool IsOpened { get; set; }
        public bool IsScrap { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public bool? IsAttributeItem { get; set; }
        public bool? IsDimension { get; set; }
        public bool? AllPatchesSamePrice { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? CoastAverage { get; set; }
    }
}
