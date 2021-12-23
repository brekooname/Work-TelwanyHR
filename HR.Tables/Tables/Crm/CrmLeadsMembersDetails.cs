using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CrmLeadsMembersDetails
    {
        public int LeadMemberDetailId { get; set; }
        public int? LeadMemberId { get; set; }
        public int? LeadId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual CrmLeadsMembers LeadMember { get; set; }
    }
}
