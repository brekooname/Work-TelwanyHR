using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobSwages
    {
        public int JobStechId { get; set; }
        public int? JorderId { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName1 { get; set; }
        public decimal? TotalHours { get; set; }
        public decimal? HourlyCostRate { get; set; }
        public decimal? Wvalue { get; set; }
        public string Wdescription { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
