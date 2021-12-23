using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPaymentNoteCurrencies
    {
        public int PayCurId { get; set; }
        public int? PayId { get; set; }
        public int? CurrencyCategoryId { get; set; }
        public decimal? Value { get; set; }
        public decimal? Count { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }

        public virtual MsPaymentNote Pay { get; set; }
    }
}
