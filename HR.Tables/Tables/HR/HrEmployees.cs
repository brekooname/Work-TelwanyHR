using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmployees
    {
        public HrEmployees()
        {
            CalEmpAccounts = new HashSet<CalEmpAccounts>();
            HrEmpSalaryTypes = new HashSet<HrEmpSalaryTypes>();
            MsCheqBooks = new HashSet<MsCheqBooks>();
            ProjProjectItemEmpJoin = new HashSet<ProjProjectItemEmpJoin>();
            SrEmpServicTypes = new HashSet<SrEmpServicTypes>();
            SrTaskEmp = new HashSet<SrTaskEmp>();
        }

        public int EmpId { get; set; }
        public int? StoreId { get; set; }
        public int? JobId { get; set; }
        public int? LocationId { get; set; }
        public int? DepartMentId { get; set; }
        public int? HrempGroupId { get; set; }
        public int? PeriodTableId { get; set; }
        public int? ShiftId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CostCenterId1 { get; set; }
        public int? CostCenterId2 { get; set; }
        public string EmpCode { get; set; }
        public string DeviceEmpCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Qualification { get; set; }
        public bool? Gender { get; set; }
        public byte? MaritalStatus { get; set; }
        public byte? KidsNo { get; set; }
        public byte? Religion { get; set; }
        public byte? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Remarks { get; set; }
        public string Idno { get; set; }
        public DateTime? IdissueDate { get; set; }
        public DateTime? IdexpiryDate { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string Car { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime? DrivingIssueDate { get; set; }
        public DateTime? DrivingExpiryDate { get; set; }
        public DateTime? DrivingRenewalDate { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public byte? AnnualVacs { get; set; }
        public byte? ReservedVacs { get; set; }
        public DateTime? LastVacsUpdate { get; set; }
        public byte? AnnualVacsBalance { get; set; }
        public byte? ReservedVacsBalance { get; set; }
        public byte? MaxVacsBalance { get; set; }
        public bool? ContractType { get; set; }
        public bool? Attendance { get; set; }
        public DateTime? ContractSrtDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public string SocialSecurityId { get; set; }
        public string HealthInsId { get; set; }
        public DateTime? HealthInsEndDate { get; set; }
        public string Syndicate { get; set; }
        public string SyndicateId { get; set; }
        public string ImageUrl { get; set; }
        public byte? MilitaryService { get; set; }
        public decimal? HourlyCostRate { get; set; }
        public bool? IsTechnician { get; set; }
        public bool? IsSales { get; set; }
        public bool? IsMoneyCollector { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public byte[] EmpImage { get; set; }
        public bool? IssueSalary { get; set; }
        public bool? DistributeSalary { get; set; }
        public bool? AutosalaryIssue { get; set; }
        public string BankName { get; set; }
        public string BankAccNo { get; set; }
        public decimal? Salary { get; set; }
        public decimal? DailyCost { get; set; }
        public decimal? HourlyCost { get; set; }
        public decimal? TotalDailyCost { get; set; }
        public decimal? TotalHourlyCost { get; set; }
        public decimal? CommisionPercent { get; set; }
        public decimal? CommisionCollectionPerc { get; set; }
        public bool? IsCommissionAfterDisc { get; set; }

        public virtual HrDepartments DepartMent { get; set; }
        public virtual HrEmpGroups HrempGroup { get; set; }
        public virtual HrJobs Job { get; set; }
        public virtual HrPeriodsTables PeriodTable { get; set; }
        public virtual HrShifts Shift { get; set; }
        public virtual ICollection<CalEmpAccounts> CalEmpAccounts { get; set; }
        public virtual ICollection<HrEmpSalaryTypes> HrEmpSalaryTypes { get; set; }
        public virtual ICollection<MsCheqBooks> MsCheqBooks { get; set; }
        public virtual ICollection<ProjProjectItemEmpJoin> ProjProjectItemEmpJoin { get; set; }
        public virtual ICollection<SrEmpServicTypes> SrEmpServicTypes { get; set; }
        public virtual ICollection<SrTaskEmp> SrTaskEmp { get; set; }
        public virtual ICollection<HrEmpStore> HrEmpStores { get; set; }
        public virtual ICollection<HrEmpShift> HrEmpShifts { get; set; }
        public virtual ICollection<HrEmpLocations> HrEmpLocations { get; set; }
    }
}
