using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdSettings
    {
        public int ProdSettingId { get; set; }
        public int? BookId { get; set; }
        public int? FinishedProdValAccId { get; set; }
        public int? UndercostOperationAccId { get; set; }
        public int? DirectWorkersAccId { get; set; }
        public int? DirectServiceAccId { get; set; }
        public int? DirectEquipmentAccId { get; set; }
        public int? OtherCostsAccId { get; set; }
        public int? AccompanyproductsAccId { get; set; }
        public int? ScrapAccId { get; set; }
        public int? OutSourceCost { get; set; }
        public int? CostingAdjustmentId { get; set; }
        public byte? StandardCostPriority1 { get; set; }
        public byte? StandardCostPriority2 { get; set; }
        public byte? StandardCostPriority3 { get; set; }
        public decimal? DailyWorkHours { get; set; }
        public bool? EmpDataSource { get; set; }
        public decimal? MonthlyStandardWorkDays { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
