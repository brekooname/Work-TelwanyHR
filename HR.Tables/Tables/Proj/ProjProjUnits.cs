using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnits
    {
        public ProjProjUnits()
        {
            ProjProjInsuranceUnit = new HashSet<ProjProjInsuranceUnit>();
            ProjProjUnitDocument = new HashSet<ProjProjUnitDocument>();
            ProjProjUnitExploitJoin = new HashSet<ProjProjUnitExploitJoin>();
            ProjProjUnitInstallTemp = new HashSet<ProjProjUnitInstallTemp>();
            ProjProjUnitOccupTypeJoin = new HashSet<ProjProjUnitOccupTypeJoin>();
            ProjProjUnitOwnerJoin = new HashSet<ProjProjUnitOwnerJoin>();
            ProjProjUnitPermitActivityJoin = new HashSet<ProjProjUnitPermitActivityJoin>();
            ProjProjUnitPerspectiveJoin = new HashSet<ProjProjUnitPerspectiveJoin>();
            ProjProjUnitPicture = new HashSet<ProjProjUnitPicture>();
            ProjProjUnitService = new HashSet<ProjProjUnitService>();
            ProjProjUnitSubUnits = new HashSet<ProjProjUnitSubUnits>();
        }

        public int ProjUnitId { get; set; }
        public int? ProjectId { get; set; }
        public int? UnittypeId { get; set; }
        public int? UnitStatId { get; set; }
        public int? UnitDegreeId { get; set; }
        public int? UnFinLevelId { get; set; }
        public int? UnitInsurstatId { get; set; }
        public int? ParkingId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? RentCaseId { get; set; }
        public int? TermId { get; set; }
        public int? CurrencyId { get; set; }
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int? RoomCount { get; set; }
        public int? FloorNumber { get; set; }
        public long? WaterCounter { get; set; }
        public long? ElectricityCounter { get; set; }
        public bool? CalcAllMeters { get; set; }
        public decimal? BuildingArea { get; set; }
        public decimal? BuildingMeterPrice { get; set; }
        public decimal? UnitArea { get; set; }
        public decimal? UnitMeterPrice { get; set; }
        public decimal? EstimatedUnitArea { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool? CommissionIsPercent { get; set; }
        public decimal? CommissionValue { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? UnitStartDate { get; set; }
        public DateTime? UnitExpectedStartDate { get; set; }
        public decimal? ParkArea { get; set; }
        public decimal? ParkMeterPrice { get; set; }
        public decimal? RoofArea { get; set; }
        public decimal? RoofMeterPrice { get; set; }
        public decimal? GardenArea { get; set; }
        public decimal? GardenMeterPrice { get; set; }
        public decimal? BaseMentArea { get; set; }
        public decimal? BasementMeterPrice { get; set; }
        public bool? CanSaleUnits { get; set; }
        public bool? CanRentUnits { get; set; }
        public bool? ProjectStopped { get; set; }
        public bool? Sold { get; set; }
        public string ContractDocNo { get; set; }
        public DateTime? ContractDate { get; set; }
        public bool? Reserved { get; set; }
        public DateTime? ReserveDate { get; set; }
        public string ReserveDocNo { get; set; }
        public bool? Rented { get; set; }
        public DateTime? RentDate { get; set; }
        public string RentDocNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ProjProjects Project { get; set; }
        public virtual ICollection<ProjProjInsuranceUnit> ProjProjInsuranceUnit { get; set; }
        public virtual ICollection<ProjProjUnitDocument> ProjProjUnitDocument { get; set; }
        public virtual ICollection<ProjProjUnitExploitJoin> ProjProjUnitExploitJoin { get; set; }
        public virtual ICollection<ProjProjUnitInstallTemp> ProjProjUnitInstallTemp { get; set; }
        public virtual ICollection<ProjProjUnitOccupTypeJoin> ProjProjUnitOccupTypeJoin { get; set; }
        public virtual ICollection<ProjProjUnitOwnerJoin> ProjProjUnitOwnerJoin { get; set; }
        public virtual ICollection<ProjProjUnitPermitActivityJoin> ProjProjUnitPermitActivityJoin { get; set; }
        public virtual ICollection<ProjProjUnitPerspectiveJoin> ProjProjUnitPerspectiveJoin { get; set; }
        public virtual ICollection<ProjProjUnitPicture> ProjProjUnitPicture { get; set; }
        public virtual ICollection<ProjProjUnitService> ProjProjUnitService { get; set; }
        public virtual ICollection<ProjProjUnitSubUnits> ProjProjUnitSubUnits { get; set; }
    }
}
