using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class QualityItemRecCheck
    {
        public QualityItemRecCheck()
        {
            QualityItemRecCheckDetail = new HashSet<QualityItemRecCheckDetail>();
            QualityItemRecPackages = new HashSet<QualityItemRecPackages>();
        }

        public int ItemRecQualityId { get; set; }
        public int? ProdItemRecId { get; set; }
        public int? StoreEmpId { get; set; }
        public int? StoreId { get; set; }
        public int? CustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? Aid { get; set; }
        public int TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public decimal? Rate { get; set; }
        public int? TotalPieces { get; set; }
        public string DocBarCode { get; set; }
        public bool? Executed { get; set; }
        public int? PackageCount { get; set; }
        public decimal? NetPrice { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public bool? NotificationSent { get; set; }
        public bool? Approved { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? Closed { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public int? UnclosedBy { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public bool? IsPos { get; set; }
        public int? ShiftId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QualityItemRecCheckDetail> QualityItemRecCheckDetail { get; set; }
        public virtual ICollection<QualityItemRecPackages> QualityItemRecPackages { get; set; }
    }
}
