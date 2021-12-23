using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrTaskItem
    {
        public int TskItemId { get; set; }
        public int? TaskId { get; set; }
        public int? ItemCardId { get; set; }
        public string HowUse { get; set; }

        public virtual MsItemCard ItemCard { get; set; }
        public virtual SrTasks Task { get; set; }
    }
}
