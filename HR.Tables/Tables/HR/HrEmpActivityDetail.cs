using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpActivityDetail
    {
        public HrEmpActivityDetail()
        {
            HrActivityDetailElements = new HashSet<HrActivityDetailElements>();
        }

        public int EmpActivityDetailId { get; set; }
        public int? EmpActivityId { get; set; }
        public int? EmpId { get; set; }

        public virtual HrEmpActivity EmpActivity { get; set; }
        public virtual ICollection<HrActivityDetailElements> HrActivityDetailElements { get; set; }
    }
}
