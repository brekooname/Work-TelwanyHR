using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsSalesInvoiceQualityDeliveryDocs
    {
        public int QualitySaleDelId { get; set; }
        public int? ItemDeliverId { get; set; }
        public int? InvId { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual MsSalesInvoice Inv { get; set; }
    }
}
