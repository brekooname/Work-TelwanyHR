using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrPeriodTableVacations
    {
        public int PeriodVacatId { get; set; }
        public int? PeriodTableId { get; set; }
        public DateTime? VacationDate { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        public virtual HrPeriodsTables PeriodTable { get; set; }
    }
}
