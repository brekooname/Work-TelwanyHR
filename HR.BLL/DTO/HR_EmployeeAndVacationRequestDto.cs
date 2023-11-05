using HR.Tables.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.BLL.DTO
{
    public class HR_EmployeeAndVacationRequestDto
    {
        public int EmpId { get; set; }
        public int VacRequestId { get; set; }
        
        public int VacaEmpId { get; set; }
        
        public IEnumerable<HrEmployees>? EmployeeName { get; set; }

        public string name { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime ToDate { get; set; }
        

        public DateTime CloseDate { get; set; }
   

        public int DayCount { get; set; }

        public bool? Closed { get; set; }

        public string? Remarks1 { get; set; }
   
        public string? Remarks3 { get; set; }


    }
}
