using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalAccountingFix
    {
        public int AccRecalcId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TrDate { get; set; }
        public string Reason { get; set; }
    }
}
