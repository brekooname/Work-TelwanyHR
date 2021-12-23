using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrContainerTypes
    {
        public SrContainerTypes()
        {
            SrTrafficLinePriceList = new HashSet<SrTrafficLinePriceList>();
        }

        public int ContainerTypeId { get; set; }
        public int? VehicleShapeId { get; set; }
        public int? VehicleTypId { get; set; }
        public string ContainerCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string UseDesc { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SrTrafficLinePriceList> SrTrafficLinePriceList { get; set; }
    }
}
