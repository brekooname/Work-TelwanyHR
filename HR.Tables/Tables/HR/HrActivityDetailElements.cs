using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrActivityDetailElements
    {
        public int ActivityElementId { get; set; }
        public int? EmpActivityDetailId { get; set; }
        public int? EmpActivityId { get; set; }
        public int? PeriodTableId { get; set; }
        public int? PeriodTablDetailId { get; set; }
        public int? EmpId { get; set; }
        public int? AttendElementId { get; set; }
        public int? EmpElementId { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Value { get; set; }

        public virtual HrEmpActivityDetail EmpActivityDetail { get; set; }
    }
}
