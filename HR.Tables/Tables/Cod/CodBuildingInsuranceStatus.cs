using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CodBuildingInsuranceStatus
    {
        public CodBuildingInsuranceStatus()
        {
            ProjProjInsurance = new HashSet<ProjProjInsurance>();
        }

        public int BuildInsurStatId { get; set; }
        public int Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public int? Aid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }

        public virtual ICollection<ProjProjInsurance> ProjProjInsurance { get; set; }
    }
}
