using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCustomer
    {
        public MsCustomer()
        {
            CalCustAccounts = new HashSet<CalCustAccounts>();
            LaLands = new HashSet<LaLands>();
            LaPropSerial = new HashSet<LaPropSerial>();
            MsCusromerUsers = new HashSet<MsCusromerUsers>();
            MsCustImgs = new HashSet<MsCustImgs>();
            MsCustomerBranches = new HashSet<MsCustomerBranches>();
            MsCustomerContacts = new HashSet<MsCustomerContacts>();
            MsSalesInvoice = new HashSet<MsSalesInvoice>();
        }

        public int CustomerId { get; set; }
        public int? CustomerCatId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CityId { get; set; }
        public int? EmpId { get; set; }
        public int? CostCenterId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string CustomerDescE { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsTaxExempted { get; set; }
        public int? CreditPeriod { get; set; }
        public byte? PeriodType { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CreditLimitAllowed { get; set; }
        public string Nationality { get; set; }
        public string Tel { get; set; }
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
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Tel4 { get; set; }
        public string Tel5 { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PassPortNo { get; set; }
        public DateTime? PassPortIssueDate { get; set; }
        public DateTime? PassPortExpiryDate { get; set; }
        public string PassPortIssuePlace { get; set; }
        public bool? InternationalLicense { get; set; }
        public string CarLicenseNo { get; set; }
        public DateTime? CarLicenseIssueDate { get; set; }
        public string CarLicenseIssuePlace { get; set; }
        public DateTime? CarLicenseExpiryDate { get; set; }
        public DateTime? DtReg { get; set; }
        public DateTime? DtRegRenew { get; set; }
        public string Company { get; set; }
        public string CustJob { get; set; }
        public string CustId { get; set; }
        public byte? Barcode { get; set; }
        public byte? SalPrice { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public decimal? DefaultDisc { get; set; }
        public decimal? ReportDiscValu { get; set; }
        public bool? DiscPercentOrVal { get; set; }
        public bool? ForAdjustOnly { get; set; }
        public int? CostCenterId1 { get; set; }
        public int? CostCenterId2 { get; set; }
        public int? StoreId { get; set; }
        public int? TaxesId1 { get; set; }
        public int? TaxesId2 { get; set; }
        public int? TaxesId3 { get; set; }
        public bool? IsDiscountByItem { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsCreditEnabled { get; set; }
        public bool? IsPricIncludTax { get; set; }
        public string TaxExemptionNo { get; set; }
        public string TaxRefNo { get; set; }
        public decimal? PrePaidPercent { get; set; }
        public string PostalCode { get; set; }
        public string HomePage { get; set; }
        public byte? InvoiceCopies { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual MsCurrency Currency { get; set; }
        public virtual MsCustomerCategory CustomerCat { get; set; }
        public virtual MsCustomerTypes CustomerType { get; set; }
        public virtual ICollection<CalCustAccounts> CalCustAccounts { get; set; }
        public virtual ICollection<LaLands> LaLands { get; set; }
        public virtual ICollection<LaPropSerial> LaPropSerial { get; set; }
        public virtual ICollection<MsCusromerUsers> MsCusromerUsers { get; set; }
        public virtual ICollection<MsCustImgs> MsCustImgs { get; set; }
        public virtual ICollection<MsCustomerBranches> MsCustomerBranches { get; set; }
        public virtual ICollection<MsCustomerContacts> MsCustomerContacts { get; set; }
        public virtual ICollection<MsSalesInvoice> MsSalesInvoice { get; set; }
    }
}
