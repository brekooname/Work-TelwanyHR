using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdProductionLine
    {
        public ProdProductionLine()
        {
            ProdProductionLineDetails = new HashSet<ProdProductionLineDetails>();
        }

        public int ProLineId { get; set; }
        public int? ProdLinCode { get; set; }
        public string ProdLinName1 { get; set; }
        public string ProdLinName2 { get; set; }
        public string ProdLinDesc { get; set; }
        public int? ItemCardId { get; set; }
        public int? UnitId { get; set; }
        public int? ItemAtrribBatchId { get; set; }
        public decimal? StandardQty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProdProductionLineDetails> ProdProductionLineDetails { get; set; }
    }
}
