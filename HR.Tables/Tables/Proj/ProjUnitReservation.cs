using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjUnitReservation
    {
        public ProjUnitReservation()
        {
            ProjProjUnitService = new HashSet<ProjProjUnitService>();
            ProjReservInstallments = new HashSet<ProjReservInstallments>();
            ProjReserveUnitDocuments = new HashSet<ProjReserveUnitDocuments>();
            ProjReserveUnitOwners = new HashSet<ProjReserveUnitOwners>();
            ProjReserveUnitSellers = new HashSet<ProjReserveUnitSellers>();
        }

        public int ReservId { get; set; }
        public int? StoreId { get; set; }
        public int? CurrencyId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? InstallTempId { get; set; }
        public int? InstallId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsCustBalancInstall { get; set; }
        public decimal? CustomerBalace { get; set; }
        public int? Aid { get; set; }
        public int? TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public decimal? Rate { get; set; }
        public int? ContractTrNo { get; set; }
        public int? ContractBookId { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PayStartDate { get; set; }
        public int? ProjUnitId { get; set; }
        public int? ProjectId { get; set; }
        public int? SalesEmpId { get; set; }
        public decimal? UnitMeterPrice { get; set; }
        public decimal? UnitArea { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? PaidInCash { get; set; }
        public decimal? ActualSalesPrice { get; set; }
        public decimal? TotalInstallments { get; set; }
        public decimal? NotPaidInstallments { get; set; }
        public decimal? CommissionPercent { get; set; }
        public decimal? CommissionValue { get; set; }
        public decimal? LeavePercent { get; set; }
        public decimal? LeaveValue { get; set; }
        public decimal? FeesPercent { get; set; }
        public decimal? FeesValue { get; set; }
        public decimal? FinishMeterPrice { get; set; }
        public decimal? FinishValue { get; set; }
        public decimal? DiscPercent { get; set; }
        public decimal? DiscValue { get; set; }
        public decimal? TotalServices { get; set; }
        public decimal? TotalUnitArea { get; set; }
        public bool? IsContract { get; set; }
        public byte? RoundType { get; set; }
        public string Remarks { get; set; }
        public bool? Closed { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public decimal? NotPaid { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProjProjUnitService> ProjProjUnitService { get; set; }
        public virtual ICollection<ProjReservInstallments> ProjReservInstallments { get; set; }
        public virtual ICollection<ProjReserveUnitDocuments> ProjReserveUnitDocuments { get; set; }
        public virtual ICollection<ProjReserveUnitOwners> ProjReserveUnitOwners { get; set; }
        public virtual ICollection<ProjReserveUnitSellers> ProjReserveUnitSellers { get; set; }
    }
}
