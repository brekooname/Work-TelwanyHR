using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitOccupTypeJoin
    {
        public int ProjUnitOccupTypeJoinId { get; set; }
        public int? ProjUnitId { get; set; }
        public int? UnitOccuTypeId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual ProjProjUnits ProjUnit { get; set; }
        public virtual CodUnitOccupancyTypes UnitOccuType { get; set; }
    }
}
