using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsTerms
    {
        public MsTerms()
        {
            MsTermsCostCenter = new HashSet<MsTermsCostCenter>();
            MsTermsDetails = new HashSet<MsTermsDetails>();
        }

        public int TermId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public byte? TermType { get; set; }
        public int? BookId { get; set; }
        public bool? SystemIssuedOnly { get; set; }
        public int? JournalEntryBookId { get; set; }
        public int? JournalEntryTermId { get; set; }
        public int? InventoryBookId { get; set; }
        public int? InventoryTermId { get; set; }
        public bool? IsOpenningTerm { get; set; }
        public bool? CashOrCredit { get; set; }
        public bool? IsStopped { get; set; }
        public bool? IsDefaultTerm { get; set; }
        public byte? UseItemTax { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsTermsCostCenter> MsTermsCostCenter { get; set; }
        public virtual ICollection<MsTermsDetails> MsTermsDetails { get; set; }
    }
}
