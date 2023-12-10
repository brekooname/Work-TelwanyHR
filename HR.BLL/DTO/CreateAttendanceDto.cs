using HR.Tables.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.BLL.DTO
{
    public class CreateAttendanceDto
    {
        public int AttendanceId { get; set; }
        [Required(ErrorMessage = "يجب اختيار التاريخ و الوقت")]
        public DateTime? TrDate { get; set; }
        [Required(ErrorMessage = "يجب اختيار اذا كان حضور أم إنصراف")]

        public bool? In { get; set; }
        //public bool? Out { get; set; }
        //public bool? Status { get; set; }
        //public double? Distance { get; set; }
        //public string Qr { get; set; }
        public HrShifts HrShifts { get; set; }
        public HrEmployees HrEmployees { get; set; }
        public MsStores MsStores { get; set; }
        [Required(ErrorMessage = "يجب اختيار الموظف")]
        public int? Emp_Id { get; set; }
        public IEnumerable<HrEmployees> Employees { get; set; }
        [Required(ErrorMessage = "يجب اختيار الفرع")]

        public int? StoreId { get; set; }
        public IEnumerable<MsStores> stores { get; set; }
        [Required(ErrorMessage ="يجب اختيار الشفت")]

        public int? ShftId { get; set; }
        public IEnumerable<HrShifts> shifts { get; set; }
    }
}
