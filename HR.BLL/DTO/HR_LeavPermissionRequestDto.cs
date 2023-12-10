using HR.Tables.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class HR_LeavPermissionRequestDto
    {
        public int LeavPermReqId { get; set; }

        public int EmpId { get; set; }
        public string Name1 { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int HoursCount { get; set; }
        public DateTime CloseDate { get; set; }


        //public int DayCount { get; set; }

        public bool? Closed { get; set; }

        public string? Remarks1 { get; set; }

        public string? Remarks3 { get; set; }

    }
}
