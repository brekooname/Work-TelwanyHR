using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdJobOrderEquipCostDocDetail
    {
        public int JorderEquipDocDetailId { get; set; }
        public int? JorderEquipDocId { get; set; }
        public int? EquipId { get; set; }
        public int? TaskId { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public decimal? ExecutTime { get; set; }
        public decimal? CostHour { get; set; }
        public decimal? TotalCost { get; set; }

        public virtual ProdJobOrderEquipCostDoc JorderEquipDoc { get; set; }
    }
}
