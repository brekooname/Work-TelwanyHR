using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsgaCity
    {
        public MsgaCity()
        {
            SrExtension = new HashSet<SrExtension>();
            SrHotels = new HashSet<SrHotels>();
        }

        public int CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public string Remarks { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? SysCityId { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<SrExtension> SrExtension { get; set; }
        public virtual ICollection<SrHotels> SrHotels { get; set; }
    }
}
