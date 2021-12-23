using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCurrencyCategoryJoin
    {
        public int CurrencyCatJoinId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CurrencyCategoryId { get; set; }
        public byte? CurrencyType { get; set; }

        public virtual MsCurrency Currency { get; set; }
        public virtual MsCurrencyCategory CurrencyCategory { get; set; }
    }
}
