using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsStockRecriptExpenses
    {
        public int StockRecExpenseId { get; set; }
        public int? StockRecId { get; set; }
        public int? ExpensesId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? ValueCurrency { get; set; }
        public decimal? ValueAfterRate { get; set; }
        public string Remarks { get; set; }
        public int? CreditAccountId { get; set; }

        public virtual MsStockRecript StockRec { get; set; }
    }
}
