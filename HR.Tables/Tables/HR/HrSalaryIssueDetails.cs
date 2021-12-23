using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrSalaryIssueDetails
    {
        public int SalaryIssuDetailId { get; set; }
        public int? SalaryIssuDocId { get; set; }
        public int? SalaryTypId { get; set; }
        public decimal? ElementCount { get; set; }
        public string ElementCountDesc { get; set; }
        public decimal? ElementUnitValue { get; set; }
        public decimal? AddValue { get; set; }
        public decimal? DeductValue { get; set; }
        public decimal? OtherValue { get; set; }
        public int? DebitAccountId { get; set; }
        public int? CreditAccountId { get; set; }
        public int? DebitCostcenterId { get; set; }
        public int? CreditCostCenterId { get; set; }
        public int? DebitEmpAccountId { get; set; }
        public int? CreditEmpAccountId { get; set; }

        public virtual HrSalaryIssueDoc SalaryIssuDoc { get; set; }
    }
}
