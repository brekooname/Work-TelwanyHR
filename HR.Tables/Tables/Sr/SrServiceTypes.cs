using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrServiceTypes
    {
        public SrServiceTypes()
        {
            SrEmpServicTypes = new HashSet<SrEmpServicTypes>();
            SrJobOrder = new HashSet<SrJobOrder>();
        }

        public int SrTypId { get; set; }
        public string SrCode { get; set; }
        public string SrName1 { get; set; }
        public string SrName2 { get; set; }
        public string SrDesc { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SrEmpServicTypes> SrEmpServicTypes { get; set; }
        public virtual ICollection<SrJobOrder> SrJobOrder { get; set; }
    }
}
