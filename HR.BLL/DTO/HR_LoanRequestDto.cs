using HR.Tables.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class HR_LoanRequestDto
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public int EmpLoanReqId { get; set; }

        public float LoanValue { get; set; }
        public int Installments { get; set; }

        

        public DateTime fromDate { get; set; }

        public DateTime ToDate { get; set; }


        public DateTime CloseDate { get; set; }


        public int DayCount { get; set; }

        public bool? Closed { get; set; }

        public string? Remarks1 { get; set; }

        public string? Remarks3 { get; set; }
    }
}
