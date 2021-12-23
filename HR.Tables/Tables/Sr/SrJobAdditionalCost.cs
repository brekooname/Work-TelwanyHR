using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobAdditionalCost
    {
        public int AddCostId { get; set; }
        public int? JorderId { get; set; }
        public string AddCostDesc { get; set; }
        public decimal? AdCostValue { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
