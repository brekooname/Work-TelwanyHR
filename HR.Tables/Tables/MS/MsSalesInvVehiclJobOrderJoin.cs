using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSalesInvVehiclJobOrderJoin
    {
        public int SalesVehiclJobOrderId { get; set; }
        public int? InvId { get; set; }
        public int? VjorderId { get; set; }
        public string Remarks { get; set; }

        public virtual MsSalesInvoice Inv { get; set; }
        public virtual SrVehicleJobOrder Vjorder { get; set; }
    }
}
