using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CodPackingSize
    {
        public CodPackingSize()
        {
            MsItemUnitPackingJoin = new HashSet<MsItemUnitPackingJoin>();
        }

        public int PackSizeId { get; set; }
        public int Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public int? Aid { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Hieght { get; set; }
        public decimal? LengthMeter { get; set; }
        public decimal? LengthCentimeter { get; set; }
        public decimal? LengthMillimeters { get; set; }
        public decimal? WidthMeter { get; set; }
        public decimal? WidthCentimeter { get; set; }
        public decimal? WidthMillimeters { get; set; }
        public decimal? HeightMeter { get; set; }
        public decimal? HeightCentimeter { get; set; }
        public decimal? HeightMillimeters { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Wheight { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual ICollection<MsItemUnitPackingJoin> MsItemUnitPackingJoin { get; set; }
    }
}
