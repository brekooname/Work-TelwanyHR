using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CodLandPermitActivJoin
    {
        public int LandPermitActivJoinId { get; set; }
        public int? LandId { get; set; }
        public int? LandPermitActivId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual CodLands Land { get; set; }
        public virtual CodLandPermtActiv LandPermitActiv { get; set; }
    }
}
