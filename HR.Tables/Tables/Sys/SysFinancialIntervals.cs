using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysFinancialIntervals
    {
        public int FinancialIntervalsId { get; set; }
        public string FinancialIntervalCode { get; set; }
        public string MonthNameA { get; set; }
        public string MonthNameE { get; set; }
        public DateTime? StartingFrom { get; set; }
        public string StartingFromHijri { get; set; }
        public DateTime? EndingDate { get; set; }
        public string EndToHijri { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsInUse { get; set; }
        public string StopReason { get; set; }
        public int? StoppedByUserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? FinancialYearId { get; set; }

        public virtual SysFinancialYears FinancialYear { get; set; }
    }
}
