using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrPeriodTableDetail
    {
        public int PeriodTablDetailId { get; set; }
        public int? PeriodTableId { get; set; }
        public string SubPeriodCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public DateTime? PeriodStrtDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public DateTime? PayDayDate { get; set; }
        public decimal? TotalWorkDays { get; set; }
        public decimal? TotalWorkHours { get; set; }
        public decimal? TotalVacsDays { get; set; }
        public decimal? TotalVacsHours { get; set; }

        public virtual HrPeriodsTables PeriodTable { get; set; }
    }
}
