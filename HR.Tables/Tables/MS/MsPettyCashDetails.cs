using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPettyCashDetails
    {
        public int PettycashDetailId { get; set; }
        public int? PettycashId { get; set; }
        public int? ItemCardId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? EmpId { get; set; }
        public int? ExpensesId { get; set; }
        public int? AccountId { get; set; }
        public int? PurInvId { get; set; }
        public int? RetSaleId { get; set; }
        public int? CostCenterId { get; set; }
        public int? UnitId { get; set; }
        public decimal? UnitRate { get; set; }
        public DateTime? ActionDate { get; set; }
        public decimal? QtyBeforRate { get; set; }
        public decimal? Quantity { get; set; }
        public byte? ItemType { get; set; }
        public bool? IsStockRelated { get; set; }
        public decimal? PaidPrice { get; set; }
        public decimal? PriceAfterRate { get; set; }
        public bool? IsPurchase { get; set; }
        public bool? IsReturnSales { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public string Remark3 { get; set; }

        public virtual MsPettycash Pettycash { get; set; }
    }
}
