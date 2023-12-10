using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.BLL.DTO
{
    public class ModifyingAttendanceDto
    {
        public int AttendanceId { get; set; }
        [Display(Name ="الإسم :")]
        public string EmployeeName { get; set; }    
        public DateTime? TrDate { get; set; }

    }
}
