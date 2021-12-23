using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpShift
    {
        public HrEmpShift()
        {
         
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpShiftId { get; set; }
        [ForeignKey(nameof(HrShifts))]
        public int ShiftId { get; set; }
        [ForeignKey(nameof(HrEmployees))]
        public int EmpId { get; set; }
        public HrShifts HrShifts { get; set; }
        public HrEmployees HrEmployees { get; set; }
    }
}
