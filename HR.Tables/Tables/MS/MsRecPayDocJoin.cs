using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsRecPayDocJoin
    {
        public int InvRecPayId { get; set; }
        public int? PayId { get; set; }
        public int? RectId { get; set; }
        public int? DocId { get; set; }
        public byte? DocType { get; set; }
        public decimal? Paid { get; set; }
        public decimal? NotPaid { get; set; }
    }
}
