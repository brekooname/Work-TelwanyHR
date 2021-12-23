using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrPeriodsTables
    {
        public HrPeriodsTables()
        {
            HrEmployees = new HashSet<HrEmployees>();
            HrPeriodTableDetail = new HashSet<HrPeriodTableDetail>();
            HrPeriodTablePolicy = new HashSet<HrPeriodTablePolicy>();
            HrPeriodTableVacations = new HashSet<HrPeriodTableVacations>();
        }

        public int PeriodTableId { get; set; }
        public string PeriodCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public bool? AttendanceMachin { get; set; }
        public int? ShiftId { get; set; }
        public byte? PeriodsNum { get; set; }
        public byte? PeriodType { get; set; }
        public DateTime? TableStartDate { get; set; }
        public DateTime? TableEndDate { get; set; }
        public DateTime? FirstDayWork { get; set; }
        public byte? PeriodWorkDays { get; set; }
        public byte? DailyWorkHours { get; set; }
        public decimal? SubPeriodCount { get; set; }
        public byte? SubPeriodType { get; set; }
        public byte? RoundingMethod { get; set; }
        public int? WorkDayShowElementId { get; set; }
        public int? WorkDayNoShowElementId { get; set; }
        public int? Shift1ShowElementId { get; set; }
        public int? Shift1NoShowElementId { get; set; }
        public int? Shift2ShowElementId { get; set; }
        public int? Shift2NoShowElementId { get; set; }
        public int? Shift3ShowElementId { get; set; }
        public int? Shift3NoShowElementId { get; set; }
        public int? LateArrivalElementId { get; set; }
        public string LateArrivalUnit { get; set; }
        public decimal? LateArrivalRound { get; set; }
        public decimal? LateArrivalMinVal { get; set; }
        public int? EarlyLeaveElementId { get; set; }
        public string EarlyLeaveUnit { get; set; }
        public decimal? EarlyLeaveRound { get; set; }
        public decimal? EarlyLeaveMinVal { get; set; }
        public int? EarlyAttendElementId { get; set; }
        public string EarlyAttendUnit { get; set; }
        public decimal? EarlyAttendRound { get; set; }
        public decimal? EarlyAttendMinVal { get; set; }
        public int? WorkdayOvertimeElementId { get; set; }
        public string WorkdayOvertimeUnit { get; set; }
        public decimal? WorkdayOvertimeRound { get; set; }
        public decimal? WorkdayOvertimeMinVal { get; set; }
        public int? VacationOvertimeElementId { get; set; }
        public string VacationOvertimeUnit { get; set; }
        public decimal? VacationOvertimeRound { get; set; }
        public decimal? VacationOvertimeMinVal { get; set; }
        public int? WeekendOvertimeElementId { get; set; }
        public string WeekendOvertimeUnit { get; set; }
        public decimal? WeekendOvertimeRound { get; set; }
        public decimal? WeekendOvertimeMinVal { get; set; }
        public byte? WrkOvrTimAfterDismis { get; set; }
        public byte? WeekEndOvrTimAftrDismis { get; set; }
        public byte? VacOvrTimAftrDismis { get; set; }
        public bool? AcceptShiftVacs { get; set; }
        public bool? AcceptShiftHours { get; set; }
        public bool? ShiftNotAcheived { get; set; }
        public bool? AcceptShftBeforDismis { get; set; }
        public bool? CutLateTimFromOverTime { get; set; }
        public bool? CancelEarlyLeave { get; set; }
        public bool? CalcEarlyLeaveWeekEnd { get; set; }
        public bool? CalcEarlyLeaveVacation { get; set; }
        public bool? CalcLateAttendWeekEnd { get; set; }
        public bool? CalcLateAttendVacation { get; set; }
        public int? WeekEndWorkDayElementId { get; set; }
        public string WeekEndWorkUnit { get; set; }
        public decimal? WeekEndWorkRound { get; set; }
        public decimal? WeekEndWorkMinVal { get; set; }
        public int? VacationWorkDayElementId { get; set; }
        public string VacationWorkUnit { get; set; }
        public decimal? VacationWorkRound { get; set; }
        public decimal? VacationWorkMinVal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<HrEmployees> HrEmployees { get; set; }
        public virtual ICollection<HrPeriodTableDetail> HrPeriodTableDetail { get; set; }
        public virtual ICollection<HrPeriodTablePolicy> HrPeriodTablePolicy { get; set; }
        public virtual ICollection<HrPeriodTableVacations> HrPeriodTableVacations { get; set; }
    }
}
