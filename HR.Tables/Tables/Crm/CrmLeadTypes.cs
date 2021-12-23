using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CrmLeadTypes
    {
        public CrmLeadTypes()
        {
            CrmLeads = new HashSet<CrmLeads>();
        }

        public int LeadTypeId { get; set; }
        public string LeadTypeCode { get; set; }
        public string LeadTypeName1 { get; set; }
        public string LeadTypeName2 { get; set; }
        public string LeadTypeDes { get; set; }
        public string CreayedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<CrmLeads> CrmLeads { get; set; }
    }
}
