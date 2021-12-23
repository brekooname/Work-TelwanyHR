using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class GPrintLog
    {
        public int PrintLogId { get; set; }
        public int? UserId { get; set; }
        public DateTime? PrintTime { get; set; }
        public string DocName { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
    }
}
