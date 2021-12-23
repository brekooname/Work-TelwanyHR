using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SearchAdjustMent
    {
        public int TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string AdjustType { get; set; }
        public string AdjustSourceType { get; set; }
        public string AdjustSourceName { get; set; }
        public decimal? Value { get; set; }
        public string StoreDescA { get; set; }
        public int? StoreId { get; set; }
        public string DocTrNo { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? TermId { get; set; }
        public int? BookId { get; set; }
    }
}
