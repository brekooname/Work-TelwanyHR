using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjects
    {
        public ProjProjects()
        {
            ProjAccounts = new HashSet<ProjAccounts>();
            ProjEstimateItems = new HashSet<ProjEstimateItems>();
            ProjExpenses = new HashSet<ProjExpenses>();
            ProjFund = new HashSet<ProjFund>();
            ProjProjDocuments = new HashSet<ProjProjDocuments>();
            ProjProjExploitJoin = new HashSet<ProjProjExploitJoin>();
            ProjProjInsurance = new HashSet<ProjProjInsurance>();
            ProjProjOccupTypeJoin = new HashSet<ProjProjOccupTypeJoin>();
            ProjProjOwnerJoin = new HashSet<ProjProjOwnerJoin>();
            ProjProjParkingJoin = new HashSet<ProjProjParkingJoin>();
            ProjProjPermitActivityJoin = new HashSet<ProjProjPermitActivityJoin>();
            ProjProjPerspectiveJoin = new HashSet<ProjProjPerspectiveJoin>();
            ProjProjPicture = new HashSet<ProjProjPicture>();
            ProjProjUnits = new HashSet<ProjProjUnits>();
            ProjProjectItemsJoin = new HashSet<ProjProjectItemsJoin>();
            ProjRealItems = new HashSet<ProjRealItems>();
        }

        public int ProjectId { get; set; }
        public int? BuildTypeId { get; set; }
        public int? BuildStatusId { get; set; }
        public int? BuildDegreeId { get; set; }
        public int? BuildFinishLevelId { get; set; }
        public int? LandId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public int? RegionId { get; set; }
        public int? SubRegionClassId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? PostalCodId { get; set; }
        public int? RentCaseId { get; set; }
        public int? CostCenterId1 { get; set; }
        public int? CostCenterId2 { get; set; }
        public int? CostCenterId3 { get; set; }
        public int? Aid { get; set; }
        public int? CurrencyId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName1 { get; set; }
        public string ProjectName2 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Remarks { get; set; }
        public int? ParentProjectId { get; set; }
        public bool? ProjectStopped { get; set; }
        public int? ProjectStoppedbyUserId { get; set; }
        public bool? CalcAllMeters { get; set; }
        public bool? CanSaleUnits { get; set; }
        public bool? CanRentUnits { get; set; }
        public string StreetNo { get; set; }
        public string LandNo { get; set; }
        public int? FloorsCount { get; set; }
        public int? FloorUnitCount { get; set; }
        public int? FirstFloorUnitCount { get; set; }
        public int? LastFloorUnitCount { get; set; }
        public long? WaterCounter { get; set; }
        public long? ElectricityCounter { get; set; }
        public decimal? Landarea { get; set; }
        public decimal? BuildingArea { get; set; }
        public decimal? LandMeterPrice { get; set; }
        public decimal? BuildingMeterPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string NorthBoundary { get; set; }
        public string SouthBoundary { get; set; }
        public string WestBoundary { get; set; }
        public string EastBoundary { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectExpectedStartDate { get; set; }
        public byte? FundSource { get; set; }
        public decimal? PaidCapital { get; set; }
        public decimal? ProjectValue { get; set; }
        public decimal? PaidCapitalPercent { get; set; }
        public decimal? ExpectedExpense { get; set; }
        public decimal? ActualExpense { get; set; }
        public decimal? ActualExpensePercent { get; set; }
        public decimal? RemainExpense { get; set; }
        public decimal? RemainExpensePercent { get; set; }
        public decimal? CompanySharePercent { get; set; }
        public bool? CommissionIsPercent { get; set; }
        public decimal? CommissionValue { get; set; }
        public int? ProjectManagerId { get; set; }
        public decimal? CompanyShare { get; set; }
        public decimal? ParkArea { get; set; }
        public decimal? ParkMeterPrice { get; set; }
        public decimal? RoofArea { get; set; }
        public decimal? RoofMeterPrice { get; set; }
        public decimal? GardenArea { get; set; }
        public decimal? GardenMeterPrice { get; set; }
        public decimal? BaseMentArea { get; set; }
        public decimal? BasementMeterPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProjAccounts> ProjAccounts { get; set; }
        public virtual ICollection<ProjEstimateItems> ProjEstimateItems { get; set; }
        public virtual ICollection<ProjExpenses> ProjExpenses { get; set; }
        public virtual ICollection<ProjFund> ProjFund { get; set; }
        public virtual ICollection<ProjProjDocuments> ProjProjDocuments { get; set; }
        public virtual ICollection<ProjProjExploitJoin> ProjProjExploitJoin { get; set; }
        public virtual ICollection<ProjProjInsurance> ProjProjInsurance { get; set; }
        public virtual ICollection<ProjProjOccupTypeJoin> ProjProjOccupTypeJoin { get; set; }
        public virtual ICollection<ProjProjOwnerJoin> ProjProjOwnerJoin { get; set; }
        public virtual ICollection<ProjProjParkingJoin> ProjProjParkingJoin { get; set; }
        public virtual ICollection<ProjProjPermitActivityJoin> ProjProjPermitActivityJoin { get; set; }
        public virtual ICollection<ProjProjPerspectiveJoin> ProjProjPerspectiveJoin { get; set; }
        public virtual ICollection<ProjProjPicture> ProjProjPicture { get; set; }
        public virtual ICollection<ProjProjUnits> ProjProjUnits { get; set; }
        public virtual ICollection<ProjProjectItemsJoin> ProjProjectItemsJoin { get; set; }
        public virtual ICollection<ProjRealItems> ProjRealItems { get; set; }
    }
}
