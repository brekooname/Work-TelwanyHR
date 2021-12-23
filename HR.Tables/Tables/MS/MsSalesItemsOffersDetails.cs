using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSalesItemsOffersDetails
    {
        public int ItemOfferId { get; set; }
        public int? PromoOfferId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemCardId { get; set; }
        public int? BaseItemUnitId { get; set; }
        public int? OfferedItemId { get; set; }
        public int? OfferedItemUnitId { get; set; }
        public decimal? BaseItemUnitRate { get; set; }
        public decimal? BaseQty { get; set; }
        public decimal? BaseQtyBeforeRate { get; set; }
        public decimal? OfferedItemUnitRate { get; set; }
        public decimal? OfferedQty { get; set; }
        public decimal? OfferedQtyBeforeRate { get; set; }
        public decimal? BaseDiscount { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscForTotalPrice { get; set; }
        public bool? IsSeasonal { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public bool? PriceIncludTaxInSales { get; set; }

        public virtual MsSalesItemsOffers PromoOffer { get; set; }
    }
}
