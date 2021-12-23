using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjUnitHistoryLog
    {
        public int ProjUnitHistoryId { get; set; }
        public int? ProjUnitId { get; set; }
        public string TableCode { get; set; }
        public string TableEntityIdName { get; set; }
        public long? TableEntityId { get; set; }
        public string LogActionDesc { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
