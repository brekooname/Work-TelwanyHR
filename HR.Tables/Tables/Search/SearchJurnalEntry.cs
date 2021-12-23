using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SearchJurnalEntry
    {
        public string DocTrNo { get; set; }
        public string PrefixCode { get; set; }
        public int? TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string JurnalDesc { get; set; }
        public decimal? TotalDebit { get; set; }
        public decimal? TotalCredit { get; set; }
        public bool? IsOpenning { get; set; }
        public int JurnalId { get; set; }
        public int? BookId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? TermId { get; set; }
        public int? StorId { get; set; }
    }
}
