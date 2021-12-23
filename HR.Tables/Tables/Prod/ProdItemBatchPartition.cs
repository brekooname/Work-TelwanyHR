using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdItemBatchPartition
    {
        public int ItemPatchPartitionId { get; set; }
        public int? ItemAtrribBatchId { get; set; }
        public int? ItemCardId { get; set; }
        public int? StoreId { get; set; }
        public int? StorePartId { get; set; }
        public int? LotNumberExpiryId { get; set; }
        public decimal? QtyPartiation { get; set; }
        public decimal? QtyInNotebook { get; set; }
        public decimal? TotalCost { get; set; }
        public int? PurchaseNumber { get; set; }
        public decimal? Fifocost { get; set; }
        public decimal? Lifocost { get; set; }
        public decimal? CoastAverage { get; set; }
        public string BatchNumberFifoOrLifo { get; set; }
        public decimal? VarianceQty { get; set; }
        public decimal? ReservedQty { get; set; }
        public decimal? RequestedQty { get; set; }
        public decimal? SalesNotDelivered { get; set; }
        public decimal? PurNotReceived { get; set; }
        public decimal? QtyOutWithoutBalance { get; set; }
        public decimal? QtyInWithoutCost { get; set; }
        public decimal? SalesOrder { get; set; }
        public decimal? PurchaseOrder { get; set; }
        public decimal? WithoutCost { get; set; }
        public decimal? ItemLimit { get; set; }
        public decimal? ItemMax { get; set; }
        public long? Tversion { get; set; }
        public string Ttype { get; set; }

        public virtual ProdItemAttributesBatche ItemAtrribBatch { get; set; }
    }
}
