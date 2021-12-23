using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpMovePromotDetail
    {
        public int EmpMoveDetailId { get; set; }
        public int? EmpMoveId { get; set; }
        public int? EmpId { get; set; }
        public int? SalaryTypId { get; set; }
        public decimal? OldSalaryValu { get; set; }
        public decimal? SalaryValu { get; set; }

        public virtual HrEmpMovePromotion EmpMove { get; set; }
    }
}
