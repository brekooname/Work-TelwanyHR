using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrAttendElementTrans
    {
        public int ElementTransId { get; set; }
        public string TableCode { get; set; }
        public int? TableId { get; set; }
        public int? AttendElementId { get; set; }
        public int? EmpId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? PeriodTableId { get; set; }
        public int? PeriodTablDetailId { get; set; }
        public bool? IsPlus { get; set; }
        public DateTime? OriginalDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? ElementValue { get; set; }
    }
}
