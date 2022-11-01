using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Static
{
    public class LoanRequestMV
    {
        public int Id { get; set; }
        public string EmployeeArName { get; set; }
        public string EmployeeEnName { get; set; }
        public int Installments { get; set; }
        public decimal LoanValue { get; set; }
        public decimal InstallmentValue { get; set; }
        public string Remarks1 { get; set; }
        public string RequestImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
