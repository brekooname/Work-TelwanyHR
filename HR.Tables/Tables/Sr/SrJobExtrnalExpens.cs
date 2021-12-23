using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobExtrnalExpens
    {
        public int JobExpensId { get; set; }
        public int? JorderId { get; set; }
        public int? ResponsibleEmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName1 { get; set; }
        public decimal? TotalHours { get; set; }
        public decimal? Expvalue { get; set; }
        public string Expdescription { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
