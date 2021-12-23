using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCurrency
    {
        public MsCurrency()
        {
            CalJurnalDetail = new HashSet<CalJurnalDetail>();
            MsBoxCurrency = new HashSet<MsBoxCurrency>();
            MsCurrencyCategoryJoin = new HashSet<MsCurrencyCategoryJoin>();
            MsCurrencyRate = new HashSet<MsCurrencyRate>();
            MsCustomer = new HashSet<MsCustomer>();
            MsVendor = new HashSet<MsVendor>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public string CurrencyDescE { get; set; }
        public decimal? Rate { get; set; }
        public bool? DefualtCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public string FractionalUnit { get; set; }
        public byte? DecimalPlaces { get; set; }
        public int? CurrencyCategoryId { get; set; }
        public string CurrenctType { get; set; }
        public string SingleCurencyname { get; set; }
        public string SingleCurencyname2 { get; set; }
        public string DoubleCurencyname { get; set; }
        public string DoubleCurencyname2 { get; set; }
        public string CurrancyNameOverthree { get; set; }
        public string CurrancyNameOverthree2 { get; set; }
        public string CollectionCurrencyName { get; set; }
        public string CollectionCurrencyName2 { get; set; }
        public string SingleCurencyFractionname { get; set; }
        public string SingleCurencyFractionname2 { get; set; }
        public string DoubleCurencyFractionname { get; set; }
        public string DoubleCurencyFractionname2 { get; set; }
        public string CurrancyNameFractionOverthree { get; set; }
        public string CurrancyNameFractionOverthree2 { get; set; }
        public string CollectionCurrencyFractionName { get; set; }
        public string CollectionCurrencyFractionName2 { get; set; }
        public string SingleCurencyTempname { get; set; }
        public string DoubleCurencyTempname { get; set; }
        public string CurrancyNameTempOver3 { get; set; }
        public string CollectionCurrencyTempName { get; set; }
        public int? Aid { get; set; }
        public decimal? EquivalentConversionPrice { get; set; }
        public DateTime? LastModify { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<CalJurnalDetail> CalJurnalDetail { get; set; }
        public virtual ICollection<MsBoxCurrency> MsBoxCurrency { get; set; }
        public virtual ICollection<MsCurrencyCategoryJoin> MsCurrencyCategoryJoin { get; set; }
        public virtual ICollection<MsCurrencyRate> MsCurrencyRate { get; set; }
        public virtual ICollection<MsCustomer> MsCustomer { get; set; }
        public virtual ICollection<MsVendor> MsVendor { get; set; }
    }
}
