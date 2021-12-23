using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdEquipments
    {
        public ProdEquipments()
        {
            ProdEquipProfile = new HashSet<ProdEquipProfile>();
        }

        public int EquipId { get; set; }
        public string EquipCode { get; set; }
        public string EquipName1 { get; set; }
        public string EquipName2 { get; set; }
        public string Jdesc { get; set; }
        public string Remarks { get; set; }
        public decimal? StandardMonthlyCost { get; set; }
        public byte? StandardHolyDays { get; set; }
        public decimal? StandardDailyCost { get; set; }
        public decimal? StandardDailyWorkHours { get; set; }
        public decimal? StandardHourlyCost { get; set; }
        public int? NumberAvailable { get; set; }
        public decimal? TimeRate { get; set; }
        public int? BasUnitId { get; set; }
        public decimal? QtyPerUnit { get; set; }
        public decimal? IsScale { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? MinWeight { get; set; }
        public string TechnicalSpecs { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProdEquipProfile> ProdEquipProfile { get; set; }
    }
}
