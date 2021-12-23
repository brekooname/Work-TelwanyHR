using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalBudgetDetails
    {
        public int BudgetDetailId { get; set; }
        public int? BudgetId { get; set; }
        public int? AccountId { get; set; }
        public int? FromFinancialIntervalsId { get; set; }
        public int? ToFinancialIntervalsId { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public int? CostCenterId { get; set; }
        public string Remarks { get; set; }

        public virtual CalBudget Budget { get; set; }
    }
}
