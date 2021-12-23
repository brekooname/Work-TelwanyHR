using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitService
    {
        public int ProjUnitServiceId { get; set; }
        public int? ReservId { get; set; }
        public int? UnitServId { get; set; }
        public int? ProjUnitId { get; set; }
        public byte? PeriodType { get; set; }
        public byte? PeriodRepeat { get; set; }
        public decimal? ServiceValue { get; set; }
        public bool? PerUnitOrMeter { get; set; }
        public decimal? MeterCount { get; set; }
        public decimal? TotalServiceValue { get; set; }
        public bool? Installed { get; set; }
        public string Remarks { get; set; }

        public virtual ProjProjUnits ProjUnit { get; set; }
        public virtual ProjUnitReservation Reserv { get; set; }
        public virtual CodUnitServices UnitServ { get; set; }
    }
}
