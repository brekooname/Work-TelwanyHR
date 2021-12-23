using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSalesItemsOffers
    {
        public MsSalesItemsOffers()
        {
            MsSalesItemsOffersDetails = new HashSet<MsSalesItemsOffersDetails>();
        }

        public int PromoOfferId { get; set; }
        public bool? IsActiveOffer { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
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
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsSalesItemsOffersDetails> MsSalesItemsOffersDetails { get; set; }
    }
}
