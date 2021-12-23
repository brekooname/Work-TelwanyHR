using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrFlight
    {
        public int FlightId { get; set; }
        public int? TripId { get; set; }
        public string FlightCompany { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public int? TrafficLineId { get; set; }
        public int? CityIdfrom { get; set; }
        public int? CityIdto { get; set; }
        public string PlaceFrom { get; set; }
        public string PlaceTo { get; set; }
        public string Remarks { get; set; }

        public virtual SrTrips Trip { get; set; }
    }
}
