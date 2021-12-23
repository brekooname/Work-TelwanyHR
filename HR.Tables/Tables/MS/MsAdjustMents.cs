using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsAdjustMents
    {
        public MsAdjustMents()
        {
            MsCashTransactionDetail = new HashSet<MsCashTransactionDetail>();
        }

        public int AdjustId { get; set; }
        public int? StoreId { get; set; }
        public byte? CurrencyId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? PurInvId { get; set; }
        public int? InvId { get; set; }
        public int? RetPurchId { get; set; }
        public int? RetSaleId { get; set; }
        public int? RectId { get; set; }
        public int? PayId { get; set; }
        public int? DocBookId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? Aid { get; set; }
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public bool? AdjType { get; set; }
        public bool? AdjSourcType { get; set; }
        public int? AdjSourcTypeId { get; set; }
        public decimal? Value { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalCheques { get; set; }
        public decimal? TotalInvoices { get; set; }
        public decimal? NotPaidInvoices { get; set; }
        public decimal? DifferenceInvoices { get; set; }
        public decimal? ResourceBalance { get; set; }
        public bool? IsPaid { get; set; }
        public int? PaidDocId { get; set; }
        public decimal? NotPaid { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<MsCashTransactionDetail> MsCashTransactionDetail { get; set; }
    }
}
