using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SearchKeepers
    {
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string KeeperNo { get; set; }
        public bool? IsCollected { get; set; }
        public DateTime? CollectDate { get; set; }
        public bool? IsReturned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RecTrNo { get; set; }
        public DateTime? RecTrDate { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? PaidPrice { get; set; }
        public string ClientAccNo { get; set; }
        public string BankDesc { get; set; }
        public bool? IsKembiala { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string CustomerDescE { get; set; }
        public string Cc { get; set; }
        public byte? CheckType { get; set; }
        public string DocTrNo { get; set; }
        public string ManualTrNo { get; set; }
        public int KeeperId { get; set; }
        public int? BookId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? TermId { get; set; }
        public string Cc2 { get; set; }
        public int? StoreId { get; set; }
    }
}
