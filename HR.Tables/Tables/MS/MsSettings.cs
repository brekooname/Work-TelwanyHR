using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSettings
    {
        public int SettingId { get; set; }
        public bool? ExpUseColor { get; set; }
        public int? ExpPeriod { get; set; }
        public bool? ChekAlert { get; set; }
        public bool? ItemLimitAlert { get; set; }
        public bool? ItemMaxAlert { get; set; }
        public bool? AlertCustCredit { get; set; }
        public bool? AlertVendCredit { get; set; }
        public int? AlertTimeOut { get; set; }
        public bool? CustCodOrNam { get; set; }
        public bool? VendCodOrNam { get; set; }
        public bool? PartCodOrNam { get; set; }
        public byte? AccountsDecimals { get; set; }
        public byte? QuantityDicimals { get; set; }
        public byte? PriceDicimals { get; set; }
        public byte? CostDicimals { get; set; }
        public byte? ValuesDicimals { get; set; }
        public byte? PercentDicimals { get; set; }
        public byte? DimensionDicimals { get; set; }
        public byte? TimeDecimals { get; set; }
        public bool? UseBarCodes { get; set; }
        public bool? UseBasicOrAlterBarcod { get; set; }
        public bool? UseSerialNumber { get; set; }
        public bool? UseExpirySystem { get; set; }
        public bool? UseExpiryDateColumn { get; set; }
        public bool? UseProducDateColumn { get; set; }
        public bool? UseLotNumberColumn { get; set; }
        public bool? UseAlterItems { get; set; }
        public bool? UseAttributes { get; set; }
        public bool? UseHightColumn { get; set; }
        public bool? UseWidthColumn { get; set; }
        public bool? UseLengthColumn { get; set; }
        public bool? UseUnitColumn { get; set; }
        public bool? UseBrancheCodeColumn { get; set; }
        public bool? UseBrancheNameColumn { get; set; }
        public bool? UsePartitionCodeColumn { get; set; }
        public bool? UsePartitionNameColumn { get; set; }
        public byte? NoOfItemRemarksFields { get; set; }
        public string ItemCostAffectDoc { get; set; }
        public string SalesReturnItemCost { get; set; }
        public string PurchReturnItemCost { get; set; }
        public byte? AskForAttachMove { get; set; }
        public string AttachmentPath { get; set; }
        public bool? UseWeightCardSystem { get; set; }
        public bool? UseCurrency { get; set; }
        public bool? UseHijiryDate { get; set; }
        public string SysDateFormat { get; set; }
        public bool? ScaleAutoRead { get; set; }
        public string ScaleAppPath { get; set; }
        public string ScaleDataPath { get; set; }
        public byte? ItemIssueCostMethod { get; set; }
        public byte? ItemIssueWhichCost { get; set; }
        public bool? UseFinancialQtyOnly { get; set; }
        public bool? UseSimpleExpirySystem { get; set; }
        public bool? UseComposItem { get; set; }
        public bool? HideDeletedDocs { get; set; }
        public bool? HideCustBranch { get; set; }
        public bool? HideCurrency { get; set; }
        public bool? HideSalesMan { get; set; }
        public bool? HideMoneyCollector { get; set; }
        public bool? DistDiscOnJobOrderItems { get; set; }
        public bool? UseSalesJobOrders { get; set; }
        public bool? UseItemTaxInPurch { get; set; }
        public bool? UseItemTaxInSales { get; set; }
        public bool? UseAnalyticalCode { get; set; }
        public bool? UseShipping { get; set; }
        public bool? UseVehicles { get; set; }
        public int? ItemDefTax { get; set; }
        public bool? PriceIncludTaxInSales { get; set; }
        public bool? PriceIncludTaxInPurch { get; set; }
        public bool? SearchItemWithQtySales { get; set; }
    }
}
