using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class TrOpenningBalanceDetails
    {
        public int OpeningBalanceDetailsId { get; set; }
        public int? TrOpenningBalanceId { get; set; }
        public int? AccountId { get; set; }
        public int? LineNumber { get; set; }
        public decimal? Creditor { get; set; }
        public decimal? Debitor { get; set; }

        public virtual TrOpenningBalance TrOpenningBalance { get; set; }
    }
}
