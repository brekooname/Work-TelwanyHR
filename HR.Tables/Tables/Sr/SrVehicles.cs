using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrVehicles
    {
        public SrVehicles()
        {
            SrJobOrder = new HashSet<SrJobOrder>();
            SrTrafficLinePriceList = new HashSet<SrTrafficLinePriceList>();
            SrVehicleJobOrder = new HashSet<SrVehicleJobOrder>();
        }

        public int VehicleId { get; set; }
        public string VehicleCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int? InvItemCardId { get; set; }
        public int? ItemCardId { get; set; }
        public int? InvId { get; set; }
        public int? CustomerId { get; set; }
        public int? VehicleTypId { get; set; }
        public int? VehicleShapeId { get; set; }
        public int? TrafficLineId { get; set; }
        public int? Wid { get; set; }
        public int? DriverId1 { get; set; }
        public int? DriverId2 { get; set; }
        public int? GarageId { get; set; }
        public int? CostCenterId { get; set; }
        public int? CurrencyId { get; set; }
        public bool? IsCompanyCar { get; set; }
        public bool? InWarranty { get; set; }
        public string RegNo { get; set; }
        public string BodyNo { get; set; }
        public string MotorNo { get; set; }
        public long? StartCounterNo { get; set; }
        public long? CounterNo { get; set; }
        public int? YearModel { get; set; }
        public string Color { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string Remarks { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SrGarage Garage { get; set; }
        public virtual SrVehicleShapes VehicleShape { get; set; }
        public virtual SrVehicleTypes VehicleTyp { get; set; }
        public virtual SrWarranty W { get; set; }
        public virtual ICollection<SrJobOrder> SrJobOrder { get; set; }
        public virtual ICollection<SrTrafficLinePriceList> SrTrafficLinePriceList { get; set; }
        public virtual ICollection<SrVehicleJobOrder> SrVehicleJobOrder { get; set; }
    }
}
