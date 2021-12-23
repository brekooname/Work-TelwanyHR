using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCurrencyRate
    {
        public int EqualCurrencyPriceId { get; set; }
        public int? CurrencyId { get; set; }
        public int? EquivalentCurrencyId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? LastModify { get; set; }

        public virtual MsCurrency Currency { get; set; }
    }
}
