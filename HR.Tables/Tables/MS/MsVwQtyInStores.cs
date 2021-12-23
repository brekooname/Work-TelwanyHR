using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVwQtyInStores
    {
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public string PartCode { get; set; }
        public string PartDescA { get; set; }
        public int? ItemCardId { get; set; }
        public decimal? QtyPartiation { get; set; }
        public decimal? QtyInNotebook { get; set; }
        public int StoreId { get; set; }
        public int StorePartId { get; set; }
        public decimal? Fifocost { get; set; }
        public decimal? Lifocost { get; set; }
        public decimal? CoastAverage { get; set; }
        public string BatchNumberFifoOrLifo { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Period { get; set; }
        public byte? PeriodType { get; set; }
        public string LotNumberExpiry { get; set; }
        public decimal? ReservedQty { get; set; }
        public decimal? RequestedQty { get; set; }
        public decimal? SaleNotDelivered { get; set; }
        public decimal? PurNotReceived { get; set; }
        public decimal? QtyOutWithoutBalance { get; set; }
        public decimal? QtyInWithoutCost { get; set; }
        public decimal? SalesOrder { get; set; }
    }
}
