using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalAccountUsers
    {
        public int AccUserId { get; set; }
        public int? AccountId { get; set; }
        public int? UserId { get; set; }
        public int? ApprovedBy { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public bool? TranAndView { get; set; }

        public virtual CalAccountChart Account { get; set; }
        public virtual GUsers User { get; set; }
    }
}
