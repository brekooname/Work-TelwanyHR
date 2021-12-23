using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrTripAccomDetail
    {
        public int TripAccomDetailId { get; set; }
        public int? AccomodationId { get; set; }
        public int? CustomerId { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string PassPortNo { get; set; }
        public string RoomNo { get; set; }
        public int? PersonCount { get; set; }
        public string Remarks { get; set; }

        public virtual SrAccomodation Accomodation { get; set; }
    }
}
