using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsItemCard
    {
        public MsItemCard()
        {
            MsDeliverItemCard = new HashSet<MsDeliverItemCard>();
            MsItemAlternatives = new HashSet<MsItemAlternatives>();
            MsItemCardOffers = new HashSet<MsItemCardOffers>();
            MsItemCollection = new HashSet<MsItemCollection>();
            MsItemImages = new HashSet<MsItemImages>();
            MsItemPartition = new HashSet<MsItemPartition>();
            MsItemStartQty = new HashSet<MsItemStartQty>();
            MsItemStockAdjustmentDetail = new HashSet<MsItemStockAdjustmentDetail>();
            MsItemUnit = new HashSet<MsItemUnit>();
            MsItemVendors = new HashSet<MsItemVendors>();
            MsPurchOrderDetail = new HashSet<MsPurchOrderDetail>();
            MsPurchaseInvoiceItemCard = new HashSet<MsPurchaseInvoiceItemCard>();
            MsReturnPurchaseItem = new HashSet<MsReturnPurchaseItem>();
            MsReturnSalesItemCard = new HashSet<MsReturnSalesItemCard>();
            MsSalesInvoiceItemCard = new HashSet<MsSalesInvoiceItemCard>();
            MsSalesOfferItemCard = new HashSet<MsSalesOfferItemCard>();
            MsStockReceiptItemCard = new HashSet<MsStockReceiptItemCard>();
            MsStockTranItemCard = new HashSet<MsStockTranItemCard>();
            ProdItemAttributsJoin = new HashSet<ProdItemAttributsJoin>();
            ProdItemcardExpenses = new HashSet<ProdItemcardExpenses>();
            ProdJobOrderProducts = new HashSet<ProdJobOrderProducts>();
            SrTaskItem = new HashSet<SrTaskItem>();
            SrVehicleItemCard = new HashSet<SrVehicleItemCard>();
        }

        public int ItemCardId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? StoreId { get; set; }
        public int? StorePartId { get; set; }
        public int? BasUnitId { get; set; }
        public int? TaxesId1 { get; set; }
        public bool? Tax1ForSale { get; set; }
        public bool? Tax1ForPurch { get; set; }
        public byte? Tax1Style { get; set; }
        public decimal? Tax1Rate { get; set; }
        public bool? Tax1IsAccomulative { get; set; }
        public bool? Tax1PlusOrMinus { get; set; }
        public int? TaxesId2 { get; set; }
        public bool? Tax2ForSale { get; set; }
        public bool? Tax2ForPurch { get; set; }
        public byte? Tax2Style { get; set; }
        public decimal? Tax2Rate { get; set; }
        public bool? Tax2IsAccomulative { get; set; }
        public bool? Tax2PlusOrMinus { get; set; }
        public int? TaxesId3 { get; set; }
        public bool? Tax3ForSale { get; set; }
        public bool? Tax3ForPurch { get; set; }
        public byte? Tax3Style { get; set; }
        public decimal? Tax3Rate { get; set; }
        public bool? Tax3IsAccomulative { get; set; }
        public bool? Tax3PlusOrMinus { get; set; }
        public byte? ItemType { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescA { get; set; }
        public string ItemDescE { get; set; }
        public decimal? QtyPartiation { get; set; }
        public decimal? QtyInNotebook { get; set; }
        public decimal? TotalCost { get; set; }
        public int? PurchaseNumber { get; set; }
        public decimal? LastSalePrice { get; set; }
        public decimal? BeforLastCost { get; set; }
        public decimal? LastCostManual { get; set; }
        public decimal? ManualPurchasePrice { get; set; }
        public decimal? LastCost { get; set; }
        public decimal? CoastAverage { get; set; }
        public DateTime? LastPurchDate { get; set; }
        public decimal? FirstQty { get; set; }
        public decimal? FirstPrice { get; set; }
        public decimal? SecandQty { get; set; }
        public decimal? SecandPrice { get; set; }
        public decimal? ThridQty { get; set; }
        public decimal? ThirdPrice { get; set; }
        public decimal? LargeQty { get; set; }
        public decimal? LargePrice { get; set; }
        public decimal? Price5 { get; set; }
        public decimal? Quantity5 { get; set; }
        public decimal? Price6 { get; set; }
        public decimal? Price7 { get; set; }
        public decimal? Price8 { get; set; }
        public decimal? Price9 { get; set; }
        public decimal? Price10 { get; set; }
        public decimal? LeastSalesPrice { get; set; }
        public decimal? LeastProfitMargin { get; set; }
        public decimal? QtyInBox { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? Wheight { get; set; }
        public string StrCustm5 { get; set; }
        public string Remarks { get; set; }
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
        public int? ExpirPeriod { get; set; }
        public byte? PeriodType { get; set; }
        public string OfferDesc { get; set; }
        public bool? InOffer { get; set; }
        public DateTime? OfferFromDate { get; set; }
        public DateTime? OfferToDate { get; set; }
        public bool? IsOfferDiscount { get; set; }
        public bool? IsDiscountPercent { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsExpir { get; set; }
        public bool? IsAttributeItem { get; set; }
        public bool? IsCollection { get; set; }
        public bool? IsDimension { get; set; }
        public bool? IsSerialItem { get; set; }
        public bool? AllPatchesSamePrice { get; set; }
        public bool? UseSameItemAsMaterial { get; set; }
        public bool? AutoSuggestBatches { get; set; }
        public bool? CostWithDimension { get; set; }
        public byte? DimensionSalesPrice { get; set; }
        public byte[] LastUpdateTime { get; set; }
        public decimal? ItemLimit { get; set; }
        public decimal? ItemMax { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string ItemSize { get; set; }
        public string ItemColor { get; set; }
        public string SerialNoPrefix { get; set; }
        public int? WarantyPeriod { get; set; }
        public byte? WarantyPeriodType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsTempItem { get; set; }
        public int? ProductionItemUnit { get; set; }
        public bool? SpecialItemExeclud { get; set; }
        public bool? IsCommisionPercent { get; set; }
        public decimal? Commision { get; set; }
        public DateTime? CommisionEndDate { get; set; }
        public bool? IsOuterItem { get; set; }
        public bool? UseSomeSubItems { get; set; }

        public virtual MsItemCategory ItemCategory { get; set; }
        public virtual ICollection<MsDeliverItemCard> MsDeliverItemCard { get; set; }
        public virtual ICollection<MsItemAlternatives> MsItemAlternatives { get; set; }
        public virtual ICollection<MsItemCardOffers> MsItemCardOffers { get; set; }
        public virtual ICollection<MsItemCollection> MsItemCollection { get; set; }
        public virtual ICollection<MsItemImages> MsItemImages { get; set; }
        public virtual ICollection<MsItemPartition> MsItemPartition { get; set; }
        public virtual ICollection<MsItemStartQty> MsItemStartQty { get; set; }
        public virtual ICollection<MsItemStockAdjustmentDetail> MsItemStockAdjustmentDetail { get; set; }
        public virtual ICollection<MsItemUnit> MsItemUnit { get; set; }
        public virtual ICollection<MsItemVendors> MsItemVendors { get; set; }
        public virtual ICollection<MsPurchOrderDetail> MsPurchOrderDetail { get; set; }
        public virtual ICollection<MsPurchaseInvoiceItemCard> MsPurchaseInvoiceItemCard { get; set; }
        public virtual ICollection<MsReturnPurchaseItem> MsReturnPurchaseItem { get; set; }
        public virtual ICollection<MsReturnSalesItemCard> MsReturnSalesItemCard { get; set; }
        public virtual ICollection<MsSalesInvoiceItemCard> MsSalesInvoiceItemCard { get; set; }
        public virtual ICollection<MsSalesOfferItemCard> MsSalesOfferItemCard { get; set; }
        public virtual ICollection<MsStockReceiptItemCard> MsStockReceiptItemCard { get; set; }
        public virtual ICollection<MsStockTranItemCard> MsStockTranItemCard { get; set; }
        public virtual ICollection<ProdItemAttributsJoin> ProdItemAttributsJoin { get; set; }
        public virtual ICollection<ProdItemcardExpenses> ProdItemcardExpenses { get; set; }
        public virtual ICollection<ProdJobOrderProducts> ProdJobOrderProducts { get; set; }
        public virtual ICollection<SrTaskItem> SrTaskItem { get; set; }
        public virtual ICollection<SrVehicleItemCard> SrVehicleItemCard { get; set; }
    }
}
