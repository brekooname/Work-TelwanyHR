using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SearchPettycash
    {
        public string DocTrNo { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string ManualTrNo { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalPaidPrice { get; set; }
        public decimal? TotalFilteredPrice { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public string CurrencyDescE { get; set; }
        public decimal? Rate { get; set; }
        public int? BookId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? TermId { get; set; }
        public int? StorId { get; set; }
        public int? EmpId { get; set; }
        public string EmpCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}
