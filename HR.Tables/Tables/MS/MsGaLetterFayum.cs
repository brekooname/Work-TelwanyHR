using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsGaLetterFayum
    {
        public MsGaLetterFayum()
        {
            MsGaLetterFayumDetail = new HashSet<MsGaLetterFayumDetail>();
            MsGaMotorSndetail = new HashSet<MsGaMotorSndetail>();
        }

        public int LetterFayumId { get; set; }
        public int? StoreId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsGaLetterFayumDetail> MsGaLetterFayumDetail { get; set; }
        public virtual ICollection<MsGaMotorSndetail> MsGaMotorSndetail { get; set; }
    }
}
