using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrReciption
    {
        public SrReciption()
        {
            SrJobOrder = new HashSet<SrJobOrder>();
            SrReceptionImages = new HashSet<SrReceptionImages>();
            SrReciptionDetail = new HashSet<SrReciptionDetail>();
        }

        public int ReciptionId { get; set; }
        public int? StoreId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public int? CustId { get; set; }
        public int? ItemCardId { get; set; }
        public int? Vid { get; set; }
        public decimal? MileAge { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public int? RecevedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SrJobOrder> SrJobOrder { get; set; }
        public virtual ICollection<SrReceptionImages> SrReceptionImages { get; set; }
        public virtual ICollection<SrReciptionDetail> SrReciptionDetail { get; set; }
    }
}
