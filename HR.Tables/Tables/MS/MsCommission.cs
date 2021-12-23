using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCommission
    {
        public int CommissionDocId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public int? EmpId { get; set; }
        public byte? CalcMethod { get; set; }
        public decimal? CommissionPercent { get; set; }
        public decimal? CommissionValue { get; set; }
        public int? FromBookId { get; set; }
        public int? ToBookId { get; set; }
        public bool? IsPaid { get; set; }
        public int? PaidDocId { get; set; }
    }
}
