using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysCountries
    {
        public SysCountries()
        {
            CodCountry = new HashSet<CodCountry>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<CodCountry> CodCountry { get; set; }
    }
}
