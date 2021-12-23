using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdWorkOrderExpenses
    {
        public int WorkOrderExpenseId { get; set; }
        public int? WorkOrderId { get; set; }
        public int? AccountId { get; set; }
        public decimal? ExpensValue { get; set; }
        public int? CurrencyId { get; set; }
        public int? EmpId { get; set; }
        public int? BillOfMaterialId { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? BitOnClient { get; set; }

        public virtual ProdWorkOrder WorkOrder { get; set; }
    }
}
