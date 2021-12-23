using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class YearMonthes
    {
        public int YearMonthId { get; set; }
        public int? FinancialYearsId { get; set; }
        public string MontnName { get; set; }
        public int? MonthDayes { get; set; }
        public bool? IsActual { get; set; }
        public bool? IsNonActual { get; set; }
        public string CustomField { get; set; }
    }
}
