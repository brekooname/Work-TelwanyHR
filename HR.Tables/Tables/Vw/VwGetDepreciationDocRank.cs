using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwGetDepreciationDocRank
    {
        public long? RowRank { get; set; }
        public int DeprDocId { get; set; }
        public int? BookId { get; set; }
        public int TrNo { get; set; }
    }
}
