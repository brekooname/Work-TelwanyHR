using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrAccomodation
    {
        public SrAccomodation()
        {
            SrTripAccomDetail = new HashSet<SrTripAccomDetail>();
        }

        public int AccomodationId { get; set; }
        public int? TripId { get; set; }
        public int? CityId { get; set; }
        public int? HotelId { get; set; }
        public byte? AccomodationType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }

        public virtual SrHotels Hotel { get; set; }
        public virtual SrTrips Trip { get; set; }
        public virtual ICollection<SrTripAccomDetail> SrTripAccomDetail { get; set; }
    }
}
