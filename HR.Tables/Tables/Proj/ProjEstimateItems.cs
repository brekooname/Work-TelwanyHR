using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjEstimateItems
    {
        public int ProjectEstimateItemId { get; set; }
        public int? ProjectId { get; set; }
        public int? ItemCardId { get; set; }
        public int? UnitId { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeName { get; set; }
        public decimal? SuggestPrice { get; set; }
        public decimal? EstimateCost { get; set; }

        public virtual ProjProjects Project { get; set; }
    }
}
