using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsBoxTransferDetail
    {
        public int BoxTranDetailId { get; set; }
        public int? BoxTranId { get; set; }
        public int? BoxFrom { get; set; }
        public int? BoxTo { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Valu { get; set; }

        public virtual MsBoxTransferNote BoxTran { get; set; }
    }
}
