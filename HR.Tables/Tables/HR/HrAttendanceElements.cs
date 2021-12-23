using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrAttendanceElements
    {
        public int AttendElementId { get; set; }
        public string ElementCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string UnitDescription { get; set; }
        public decimal? FixedValue { get; set; }
        public byte? ValueType { get; set; }
        public byte? ElementUsage { get; set; }
        public byte? VacationEffect { get; set; }
        public bool? EnablEditOnEmpActivity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
