using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class LeavPermisionDTO
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }

    }

    public class EditLeavPermisionDTO: LeavPermisionDTO
    {
        public int leavePremisionId { get; set; }
       

    }
}
