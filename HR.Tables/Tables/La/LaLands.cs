using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class LaLands
    {
        public int LandId { get; set; }
        public int? CustomerId { get; set; }
        public int? LandMainNo { get; set; }
        public int? LandInternalNo { get; set; }
        public int? StreetNo { get; set; }
        public decimal? LandSize { get; set; }
        public bool? IsResidential { get; set; }
        public bool? RightLeft { get; set; }
        public string BasicMemeber { get; set; }

        public virtual MsCustomer Customer { get; set; }
    }
}
