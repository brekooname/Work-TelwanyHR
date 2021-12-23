using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class TrOpenningBalance
    {
        public TrOpenningBalance()
        {
            TrOpenningBalanceDetails = new HashSet<TrOpenningBalanceDetails>();
        }

        public int TrOpenningBalanceId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public int? Aid { get; set; }
        public int? BranchId { get; set; }
        public int? ExplainId { get; set; }
        public decimal? TotalDebitor { get; set; }
        public decimal? TotalCreditor { get; set; }
        public decimal? Balance { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<TrOpenningBalanceDetails> TrOpenningBalanceDetails { get; set; }
    }
}
