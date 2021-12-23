using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrTasks
    {
        public SrTasks()
        {
            SrTaskEmp = new HashSet<SrTaskEmp>();
            SrTaskItem = new HashSet<SrTaskItem>();
        }

        public int TaskId { get; set; }
        public int? ComId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName1 { get; set; }
        public string TaskName2 { get; set; }
        public string TaskDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SrComplaints Com { get; set; }
        public virtual ICollection<SrTaskEmp> SrTaskEmp { get; set; }
        public virtual ICollection<SrTaskItem> SrTaskItem { get; set; }
    }
}
