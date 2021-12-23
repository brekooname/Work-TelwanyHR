using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwGetItemAlters
    {
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public decimal? Qty { get; set; }
        public int? ItemCardId { get; set; }
        public string AlterToCod { get; set; }
        public string AlterToDesc { get; set; }
    }
}
