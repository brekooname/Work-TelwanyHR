using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCurrencyCategory
    {
        public MsCurrencyCategory()
        {
            MsCurrencyCategoryJoin = new HashSet<MsCurrencyCategoryJoin>();
        }

        public int CurrencyCategoryId { get; set; }
        public string Code { get; set; }
        public string CurrencyCategoryNameA { get; set; }
        public string CurrencyCategoryNameE { get; set; }
        public int? Aid { get; set; }
        public decimal? Value { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsCurrencyCategoryJoin> MsCurrencyCategoryJoin { get; set; }
    }
}
