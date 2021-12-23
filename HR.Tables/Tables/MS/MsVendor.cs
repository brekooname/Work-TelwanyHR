using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVendor
    {
        public MsVendor()
        {
            CalVendAccounts = new HashSet<CalVendAccounts>();
            MsItemVendors = new HashSet<MsItemVendors>();
            MsPurchasInvoice = new HashSet<MsPurchasInvoice>();
            MsVendImgs = new HashSet<MsVendImgs>();
            MsVendorBranches = new HashSet<MsVendorBranches>();
            MsVendorContacts = new HashSet<MsVendorContacts>();
            MsVendorUsers = new HashSet<MsVendorUsers>();
            ProjProjectItemsVendors = new HashSet<ProjProjectItemsVendors>();
        }

        public int VendorId { get; set; }
        public int? VendorCatId { get; set; }
        public int? VendorTypeId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CostCenterId { get; set; }
        public string VendorCode { get; set; }
        public string VendorDescA { get; set; }
        public string VendorDescE { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsTaxExempted { get; set; }
        public byte? CreditPeriodType { get; set; }
        public int? CreditPeriod { get; set; }
        public decimal? CreditLimit { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Tel4 { get; set; }
        public string Tel5 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Remarks { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public byte? Barcode { get; set; }
        public bool? ForAdjustOnly { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CostCenterId1 { get; set; }
        public int? CostCenterId2 { get; set; }
        public int? CityId { get; set; }
        public int? EmpId { get; set; }
        public int? StoreId { get; set; }
        public int? TaxesId1 { get; set; }
        public int? TaxesId2 { get; set; }
        public int? TaxesId3 { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsCreditEnabled { get; set; }
        public bool? IsPricIncludTax { get; set; }
        public string TaxExemptionNo { get; set; }
        public string TaxRefNo { get; set; }
        public decimal? PrePaidPercent { get; set; }
        public string PostalCode { get; set; }
        public string HomePage { get; set; }
        public byte? InvoiceCopies { get; set; }
        public DateTime? DtReg { get; set; }
        public DateTime? DtRegRenew { get; set; }
        public string Company { get; set; }
        public string VendJob { get; set; }
        public string VendId { get; set; }

        public virtual MsCurrency Currency { get; set; }
        public virtual MsVendorCategory VendorCat { get; set; }
        public virtual MsVendorTypes VendorType { get; set; }
        public virtual ICollection<CalVendAccounts> CalVendAccounts { get; set; }
        public virtual ICollection<MsItemVendors> MsItemVendors { get; set; }
        public virtual ICollection<MsPurchasInvoice> MsPurchasInvoice { get; set; }
        public virtual ICollection<MsVendImgs> MsVendImgs { get; set; }
        public virtual ICollection<MsVendorBranches> MsVendorBranches { get; set; }
        public virtual ICollection<MsVendorContacts> MsVendorContacts { get; set; }
        public virtual ICollection<MsVendorUsers> MsVendorUsers { get; set; }
        public virtual ICollection<ProjProjectItemsVendors> ProjProjectItemsVendors { get; set; }
    }
}
