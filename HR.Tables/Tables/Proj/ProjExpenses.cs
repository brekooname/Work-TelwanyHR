using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjExpenses
    {
        public int ProjectExpensId { get; set; }
        public int? ProjectId { get; set; }
        public int? ExpensesId { get; set; }
        public decimal? EstimateValue { get; set; }
        public decimal? EstimatePercent { get; set; }
        public decimal? RealValue { get; set; }
        public decimal? RealPercent { get; set; }

        public virtual ProjProjects Project { get; set; }
    }
}
