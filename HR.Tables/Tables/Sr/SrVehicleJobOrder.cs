using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrVehicleJobOrder
    {
        public SrVehicleJobOrder()
        {
            MsPurchInvVehicleJobOrderJoin = new HashSet<MsPurchInvVehicleJobOrderJoin>();
            MsSalesInvVehiclJobOrderJoin = new HashSet<MsSalesInvVehiclJobOrderJoin>();
            SrVehicleJobOrderDetail = new HashSet<SrVehicleJobOrderDetail>();
        }

        public int VjorderId { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? VorderTypeId { get; set; }
        public int? GarageId { get; set; }
        public int? EmpId { get; set; }
        public int? VehicleId { get; set; }
        public int? DriverId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? Aid { get; set; }
        public int? AccountId { get; set; }
        public int? AddAccountId { get; set; }
        public int? CostCenterId { get; set; }
        public int? CostCenterId2 { get; set; }
        public int? ContainerTypeId { get; set; }
        public int? CurrencyId { get; set; }
        public int? ItemCardId { get; set; }
        public string ItemNewName { get; set; }
        public string ContainerNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int? CostCenterId1 { get; set; }
        public int? CostCenterId21 { get; set; }
        public int? TrNo { get; set; }
        public string ManualTrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public long? StartCounter { get; set; }
        public long? EndCounter { get; set; }
        public DateTime? TimeToLeav { get; set; }
        public bool? IsClosed { get; set; }
        public string Supervisor { get; set; }
        public int? ContainersCount { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? TotalCost { get; set; }
        public string Remarks { get; set; }
        public bool? ShipExecuted { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Tel4 { get; set; }
        public string Tel5 { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public int? TermCostCenterId { get; set; }
        public decimal? TermCostCenterValue { get; set; }
        public bool? IsPosted { get; set; }
        public string Postedby { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool? Closed { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? UncloseDate { get; set; }
        public int? ClosedBy { get; set; }
        public int? UnclosedBy { get; set; }
        public int? PermPrinted { get; set; }
        public DateTime? PermPrintedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SrVehicles Vehicle { get; set; }
        public virtual SrVheicleJobOrderType VorderType { get; set; }
        public virtual ICollection<MsPurchInvVehicleJobOrderJoin> MsPurchInvVehicleJobOrderJoin { get; set; }
        public virtual ICollection<MsSalesInvVehiclJobOrderJoin> MsSalesInvVehiclJobOrderJoin { get; set; }
        public virtual ICollection<SrVehicleJobOrderDetail> SrVehicleJobOrderDetail { get; set; }
    }
}
