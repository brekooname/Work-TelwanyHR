using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdProductionOrderDetail
    {
        public int ProdOrderDetailId { get; set; }
        public int? ProductionOrderId { get; set; }
        public int? RecipeId { get; set; }
        public int? RecipeDetaiId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public int? ProLineId { get; set; }

        public virtual ProdProductionOrder ProductionOrder { get; set; }
    }
}
