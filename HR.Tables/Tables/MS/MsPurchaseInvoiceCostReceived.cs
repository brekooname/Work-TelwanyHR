using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPurchaseInvoiceCostReceived
    {
        public int PurNoCostStockId { get; set; }
        public int? PurInvId { get; set; }
        public int? StockRecId { get; set; }
        public string Remarks { get; set; }

        public virtual MsPurchasInvoice PurInv { get; set; }
    }
}
