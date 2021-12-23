using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysCity
    {
        public SysCity()
        {
            CodCity = new HashSet<CodCity>();
        }

        public int SysCityId { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<CodCity> CodCity { get; set; }
    }
}
