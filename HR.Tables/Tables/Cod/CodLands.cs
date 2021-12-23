using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CodLands
    {
        public CodLands()
        {
            CodLandPermitActivJoin = new HashSet<CodLandPermitActivJoin>();
            CodLandPosJoin = new HashSet<CodLandPosJoin>();
            CodLandRetainResJoin = new HashSet<CodLandRetainResJoin>();
        }

        public int LandId { get; set; }
        public int Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public int? Aid { get; set; }
        public string LandNo { get; set; }
        public decimal? Landarea { get; set; }
        public decimal? BuildingArea { get; set; }
        public decimal? LandMeterPrice { get; set; }
        public decimal? BuildingMeterPrice { get; set; }
        public int? LandSatusId { get; set; }
        public int? LandTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual ICollection<CodLandPermitActivJoin> CodLandPermitActivJoin { get; set; }
        public virtual ICollection<CodLandPosJoin> CodLandPosJoin { get; set; }
        public virtual ICollection<CodLandRetainResJoin> CodLandRetainResJoin { get; set; }
    }
}
