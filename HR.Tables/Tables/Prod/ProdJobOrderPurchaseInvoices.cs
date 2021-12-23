using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdJobOrderPurchaseInvoices
    {
        public int JobPurchasInvId { get; set; }
        public int? PurInvId { get; set; }
        public int? JobOrderId { get; set; }
        public decimal? NetPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ProdJobOrder JobOrder { get; set; }
        public virtual MsPurchasInvoice PurInv { get; set; }
    }
}
