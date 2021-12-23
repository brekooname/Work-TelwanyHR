using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdJobOrderWorkFlow
    {
        public int JobOrderDepartId { get; set; }
        public int? JobOrderId { get; set; }
        public int? DepartMentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserId { get; set; }
        public string Note { get; set; }

        public virtual ProdJobOrder JobOrder { get; set; }
    }
}
