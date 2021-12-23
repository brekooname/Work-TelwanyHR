using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpsSalaryTemp
    {
        public int EmpsSalaryTempId { get; set; }
        public int? SalaryTypId { get; set; }
        public int? EmpId { get; set; }
        public int? JobId { get; set; }
        public int? DepartMentId { get; set; }
        public int? HrempGroupId { get; set; }
        public int? StoreId { get; set; }
        public decimal? SalaryValu { get; set; }
        public int? DebitAccId { get; set; }
        public int? CreditAccId { get; set; }
        public int? DebitCostCenterId { get; set; }
        public int? CreditCostCenterId { get; set; }
        public int? DebitEmpAccountId { get; set; }
        public int? CreditEmpAccountId { get; set; }

        public virtual HrSalaryTypes SalaryTyp { get; set; }
    }
}
