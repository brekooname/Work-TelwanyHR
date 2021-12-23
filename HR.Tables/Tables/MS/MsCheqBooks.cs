using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCheqBooks
    {
        public int CheqBookId { get; set; }
        public string CheqBookCode { get; set; }
        public string CheqBookNamAr { get; set; }
        public string CheqBookNamEn { get; set; }
        public int? StartAt { get; set; }
        public int? CheqNum { get; set; }
        public int? CurrentNum { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? EmpId { get; set; }
        public bool? EmpDefaultBook { get; set; }

        public virtual HrEmployees Emp { get; set; }
    }
}
