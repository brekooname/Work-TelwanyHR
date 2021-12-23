using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CrmSalesPlanDetail
    {
        public int SalesPlanDetailId { get; set; }
        public int? SalesPlanId { get; set; }
        public int? LeadId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Mission { get; set; }

        public virtual CrmSalesPlan SalesPlan { get; set; }
    }
}
