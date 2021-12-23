using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjFund
    {
        public int ProjectFundId { get; set; }
        public int? ProjectId { get; set; }
        public int? AccountId { get; set; }
        public string FundName1 { get; set; }
        public string FundName2 { get; set; }
        public decimal? FundPercent { get; set; }
        public decimal? FundValue { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }

        public virtual ProjProjects Project { get; set; }
    }
}
