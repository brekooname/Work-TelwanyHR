using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class LoanRequestDTO
    {
        public int EmployeeId { get; set; }
        public decimal LoanValue { get; set; }
        public decimal InstallmentValue { get; set; }
        public int InstallmentsCount { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }

    }
    public class EditLoanRequestDTO: LoanRequestDTO
    {
        public int LoanRequestId { get; set; }
       
    }
}
