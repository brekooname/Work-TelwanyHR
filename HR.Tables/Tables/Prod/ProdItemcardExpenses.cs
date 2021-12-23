using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdItemcardExpenses
    {
        public int ProdExpensId { get; set; }
        public int? ItemCardId { get; set; }
        public int? AccountId { get; set; }
        public bool? IsPercent { get; set; }
        public byte? PercentOf { get; set; }
        public decimal? ExpenseValu { get; set; }

        public virtual MsItemCard ItemCard { get; set; }
    }
}
