using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class DelayReportDTO
    {
        public int Emp_Id { get; set; }
        public int Total { get; set; }
        public string Name1 { get; set; }
        public int MinCount { get; set; }
        public decimal DelayCost { get; set; }
        public string DayMinuteWithCost { get; set; }
        public string WeekMinuteWithCost { get; set; }
        public string MonthMinuteWithCost { get; set; }
        public string YearMinuteWithCost { get; set; }
    }
}
