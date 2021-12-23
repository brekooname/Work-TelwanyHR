using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpKPIS
    {
        public HrEmpKPIS()
        {
        }

        public int EmpKPIId { get; set; }
        [ForeignKey(nameof(HrKPIS))]
        public int KPIId { get; set; }
        public HrKPIS HrKPIS { get; set; }

        [ForeignKey(nameof(HrEmployees))]
        public int EmpId { get; set; }
        public HrEmployees HrEmployees { get; set; }

        public string RemarksA { get; set; }
        public string RemarksE { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
       
        public decimal? KpiPercent { get; set; }
       

    }
}
