using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdJobOrderEquipment
    {
        public int JobEquipId { get; set; }
        public int? JobOrderId { get; set; }
        public int? JorderEquipDocDetailId { get; set; }
        public int? JorderEquipDocId { get; set; }
        public int? TaskEquipJoinId { get; set; }
        public int? EquipId { get; set; }
        public int? EquipProfileId { get; set; }
        public int? TaskId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public int? RequestedNumber { get; set; }
        public int? RealNumber { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? StandardHourlyCost { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ProdJobOrder JobOrder { get; set; }
    }
}
