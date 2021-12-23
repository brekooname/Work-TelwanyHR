using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrSalaryIssueDistribution
    {
        public int SalaryIssuDistId { get; set; }
        public int? SalaryIssuDocId { get; set; }
        public int? AccountId { get; set; }
        public int? CostCenterId { get; set; }
        public decimal? SalaryHours { get; set; }
        public decimal? SalaryDays { get; set; }
        public decimal? SalaryPercent { get; set; }
        public decimal? ValueShare { get; set; }

        public virtual HrSalaryIssueDoc SalaryIssuDoc { get; set; }
    }
}
