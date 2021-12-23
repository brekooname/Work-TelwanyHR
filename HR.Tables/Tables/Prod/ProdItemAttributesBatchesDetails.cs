using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdItemAttributesBatchesDetails
    {
        public int ItemAtrributBatchValuesId { get; set; }
        public int ItemAtrribBatchId { get; set; }
        public int? AttribValuId { get; set; }
        public int? AttributId { get; set; }
        public string AttribValueDesc { get; set; }

        public virtual ProdItemAttributesBatche ItemAtrribBatch { get; set; }
    }
}
