using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdJobOrderServices
    {
        public int JobServiceId { get; set; }
        public int? JobOrderId { get; set; }
        public int? JorderEmpDocDetailId { get; set; }
        public int? JorderEmpDocId { get; set; }
        public int? EmpId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public decimal? ServiceValue { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public decimal? OtherCost { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ProdJobOrder JobOrder { get; set; }
    }
}
