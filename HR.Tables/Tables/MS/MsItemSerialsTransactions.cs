using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsItemSerialsTransactions
    {
        public int ItemSerialTranId { get; set; }
        public int? ItemSerialId { get; set; }
        public string TableCode { get; set; }
        public int? TableEntityId { get; set; }
        public bool? IsInOrOut { get; set; }
        public int? StorePartId { get; set; }
    }
}
