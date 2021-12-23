using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrTripProgramJoin
    {
        public int TripProgramJoinId { get; set; }
        public int? TripId { get; set; }
        public int? ProgramId { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Days { get; set; }
        public string Mtscruze { get; set; }
        public byte? Number { get; set; }

        public virtual SrPrograms Program { get; set; }
        public virtual SrTrips Trip { get; set; }
    }
}
