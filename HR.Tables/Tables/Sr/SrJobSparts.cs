using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobSparts
    {
        public int JobSpareId { get; set; }
        public int? JorderId { get; set; }
        public int? ItemCardId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Spvalue { get; set; }
        public string Spdescription { get; set; }
        public int? StoreId { get; set; }
        public int? StorePartId { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
