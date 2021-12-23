using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjOccupTypeJoin
    {
        public int ProjOccupTypeJoinId { get; set; }
        public int? ProjectId { get; set; }
        public int? BuildOccupTypeId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual CodBuildOccupTypes BuildOccupType { get; set; }
        public virtual ProjProjects Project { get; set; }
    }
}
