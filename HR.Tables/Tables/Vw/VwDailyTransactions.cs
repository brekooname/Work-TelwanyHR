using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwDailyTransactions
    {
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string Remarks { get; set; }
        public string PrefixCode { get; set; }
        public string BookNameAr { get; set; }
        public string DocTrNo { get; set; }
        public bool? IsOpenningTerm { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public string Idname { get; set; }
        public string SourcTyp { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
        public string AnalizCode { get; set; }
        public string AnalizName1 { get; set; }
        public string AnalizName2 { get; set; }
        public decimal? Rate { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public string CurrencyDescE { get; set; }
        public string DocType { get; set; }
        public string DocTypeAr { get; set; }
        public int? StoreId { get; set; }
    }
}
