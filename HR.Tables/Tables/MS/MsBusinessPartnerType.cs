using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsBusinessPartnerType
    {
        public MsBusinessPartnerType()
        {
            MsBusinessPartners = new HashSet<MsBusinessPartners>();
        }

        public int BsPartnerTypeId { get; set; }
        public string PartnerTypeCode { get; set; }
        public string PartnerTypeDescA { get; set; }
        public string PartnerTypeDescE { get; set; }
        public int? PartnerTypeParent { get; set; }
        public int? PartnerTypeLevel { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsBusinessPartners> MsBusinessPartners { get; set; }
    }
}
