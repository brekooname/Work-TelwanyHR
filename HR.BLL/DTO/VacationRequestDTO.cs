using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class VacationRequestDTO
    {
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DayCount { get; set; }
        public byte? VacationType { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }
    }

    public class EditVacationRequestDTO
    {
        public int VacationRequestId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DayCount { get; set; }
        public byte? VacationType { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }

    }

    public enum VacationTypeEnum
    {
        AnnualVacation = 1, ReservedVacation = 2, Other = 3
    }


}
