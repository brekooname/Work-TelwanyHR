using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitPermitActivityJoin
    {
        public int ProjUnitPermitActivityJoinId { get; set; }
        public int? ProjUnitId { get; set; }
        public int? UnitPermitActivId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual ProjProjUnits ProjUnit { get; set; }
        public virtual CodUnitPermittedActivity UnitPermitActiv { get; set; }
    }
}
