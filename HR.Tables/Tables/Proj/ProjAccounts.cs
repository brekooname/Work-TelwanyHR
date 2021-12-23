using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjAccounts
    {
        public int ProjectAccId { get; set; }
        public int? ProjectId { get; set; }
        public int? AccountId { get; set; }
        public decimal? Value { get; set; }

        public virtual ProjProjects Project { get; set; }
    }
}
