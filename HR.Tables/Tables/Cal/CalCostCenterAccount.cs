using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalCostCenterAccount
    {
        public int CostCenterAccId { get; set; }
        public int? CostCenterId { get; set; }
        public int? AccountId { get; set; }

        public virtual CalAccountChart Account { get; set; }
        public virtual CalCostCenters CostCenter { get; set; }
    }
}
