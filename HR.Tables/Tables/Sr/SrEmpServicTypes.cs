using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrEmpServicTypes
    {
        public int SrId { get; set; }
        public int? EmpId { get; set; }
        public int? SrTypId { get; set; }

        public virtual HrEmployees Emp { get; set; }
        public virtual SrServiceTypes SrTyp { get; set; }
    }
}
