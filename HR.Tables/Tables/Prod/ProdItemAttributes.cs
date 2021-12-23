using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdItemAttributes
    {
        public ProdItemAttributes()
        {
            ProdAttributeValue = new HashSet<ProdAttributeValue>();
            ProdItemAttributsJoin = new HashSet<ProdItemAttributsJoin>();
        }

        public int AttributId { get; set; }
        public string AttributCode { get; set; }
        public string AttributName1 { get; set; }
        public string AttributName2 { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsMandatory { get; set; }
        public byte? Dimension { get; set; }
        public bool? IsFixedMenuValues { get; set; }
        public bool? IsOptionalWithAlarm { get; set; }
        public int? BasUnitId { get; set; }
        public byte? DataType { get; set; }
        public decimal? MinValu { get; set; }
        public decimal? MaxValu { get; set; }
        public decimal? IncrementalValu { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProdAttributeValue> ProdAttributeValue { get; set; }
        public virtual ICollection<ProdItemAttributsJoin> ProdItemAttributsJoin { get; set; }
    }
}
