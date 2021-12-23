using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitSubUnits
    {
        public int SubUnitId { get; set; }
        public int ProjUnitId { get; set; }
        public int SubUnittypeId { get; set; }
        public bool? CalcByMeter { get; set; }
        public decimal? MetersCount { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? MeterPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual ProjProjUnits ProjUnit { get; set; }
        public virtual CodeSubUnitTypes SubUnittype { get; set; }
    }
}
