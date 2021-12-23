using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsTaxes
    {
        public MsTaxes()
        {
            MsPurchasInvoice = new HashSet<MsPurchasInvoice>();
        }

        public int TaxesId { get; set; }
        public string TaxCode { get; set; }
        public string TaxNameA { get; set; }
        public string TaxNameE { get; set; }
        public byte? TaxStyle { get; set; }
        public decimal? TaxRate { get; set; }
        public string Remarks { get; set; }
        public int? AccountId { get; set; }
        public bool? IsAccomulative { get; set; }
        public bool? PlusOrMinus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsPurchasInvoice> MsPurchasInvoice { get; set; }
    }
}
