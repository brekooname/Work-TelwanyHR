using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrExtension
    {
        public int ExtensionId { get; set; }
        public int? TripId { get; set; }
        public int? CityId { get; set; }
        public int? HotelId { get; set; }
        public byte? Number { get; set; }
        public decimal? Price { get; set; }

        public virtual MsgaCity City { get; set; }
        public virtual SrHotels Hotel { get; set; }
        public virtual SrTrips Trip { get; set; }
    }
}
