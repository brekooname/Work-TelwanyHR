using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrPeriodTablePolicy
    {
        public int PeriodPolicyId { get; set; }
        public int? PeriodTableId { get; set; }
        public int? AttendElementId { get; set; }
        public byte? AttendUnit { get; set; }
        public decimal? Approximate { get; set; }
        public decimal? Minimum { get; set; }

        public virtual HrPeriodsTables PeriodTable { get; set; }
    }
}
