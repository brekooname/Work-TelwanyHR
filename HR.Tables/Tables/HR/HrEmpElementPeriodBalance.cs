using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpElementPeriodBalance
    {
        public int EmpElementId { get; set; }
        public int? EmpId { get; set; }
        public int? AttendElementId { get; set; }
        public int? PeriodTablDetailId { get; set; }
        public int? PeriodTableId { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? ElementValue { get; set; }
    }
}
