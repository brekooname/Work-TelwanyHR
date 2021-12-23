using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysAnalyticalCodes
    {
        public SysAnalyticalCodes()
        {
            CalAccountChart = new HashSet<CalAccountChart>();
            CalJurnalEntry = new HashSet<CalJurnalEntry>();
            CodAccountCategories = new HashSet<CodAccountCategories>();
            CodDailyAssistance = new HashSet<CodDailyAssistance>();
            SysAnalyticalCodeUpdates = new HashSet<SysAnalyticalCodeUpdates>();
        }

        public int Aid { get; set; }
        public int? ParentAid { get; set; }
        public int? CodeLevel { get; set; }
        public byte? CodeLevelType { get; set; }
        public string Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public bool? Stopped { get; set; }
        public int? AccountId { get; set; }
        public int? CostCenterId { get; set; }
        public int? AssetId { get; set; }
        public int? EmpId { get; set; }
        public int? BspartnerId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? ItemCardId { get; set; }
        public int? AccomulatAid { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public string AddField6 { get; set; }
        public string AddField7 { get; set; }
        public string AddField8 { get; set; }
        public string AddField9 { get; set; }
        public string AddField10 { get; set; }
        public string AddField11 { get; set; }
        public string AddField12 { get; set; }
        public string AddField13 { get; set; }
        public string AddField14 { get; set; }
        public string AddField15 { get; set; }
        public string AddField16 { get; set; }
        public string AddField17 { get; set; }
        public string AddField18 { get; set; }
        public string AddField19 { get; set; }
        public string AddField20 { get; set; }
        public string AddField21 { get; set; }
        public string AddField22 { get; set; }
        public string AddField23 { get; set; }
        public string AddField24 { get; set; }
        public string AddField25 { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<CalAccountChart> CalAccountChart { get; set; }
        public virtual ICollection<CalJurnalEntry> CalJurnalEntry { get; set; }
        public virtual ICollection<CodAccountCategories> CodAccountCategories { get; set; }
        public virtual ICollection<CodDailyAssistance> CodDailyAssistance { get; set; }
        public virtual ICollection<SysAnalyticalCodeUpdates> SysAnalyticalCodeUpdates { get; set; }
    }
}
