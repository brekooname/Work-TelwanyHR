using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CodAccountCategories
    {
        public CodAccountCategories()
        {
            CodAccountClassification = new HashSet<CodAccountClassification>();
        }

        public int AccountCatId { get; set; }
        public int? ParentAccountCatId { get; set; }
        public long? Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public int? Aid { get; set; }
        public byte? AccountCatType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual SysAnalyticalCodes A { get; set; }
        public virtual ICollection<CodAccountClassification> CodAccountClassification { get; set; }
    }
}
