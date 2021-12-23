using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrWarranty
    {
        public SrWarranty()
        {
            SrVehicles = new HashSet<SrVehicles>();
        }

        public int Wid { get; set; }
        public string Wcode { get; set; }
        public string Wname1 { get; set; }
        public string Wname2 { get; set; }
        public string Wconditions { get; set; }
        public byte? Wmethod { get; set; }
        public int? WperiodMonths { get; set; }
        public int? Wdistance { get; set; }
        public bool? Wuse { get; set; }
        public bool? Exemption { get; set; }
        public byte? ExemptionPercnt { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SrVehicles> SrVehicles { get; set; }
    }
}
