using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Static
{
    public class VacationRequestMV
    {
        public int Id { get; set; }
        public string EmployeeArName { get; set; }
        public string EmployeeEnName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int VacationType { get; set; }
        public string VacationTypeStr { get; set; }
        public string Remarks1 { get; set; }
        public string RequestImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
