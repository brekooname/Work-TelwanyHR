using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSalesInvJobOrderJoin
    {
        public int SalesInvJobOrderId { get; set; }
        public int? InvId { get; set; }
        public int? JobOrderId { get; set; }
        public string Remarks { get; set; }

        public virtual MsSalesInvoice Inv { get; set; }
        public virtual ProdJobOrder JobOrder { get; set; }
    }
}
