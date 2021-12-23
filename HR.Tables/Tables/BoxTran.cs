using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class BoxTran
    {
        public int BoxTranDetailId { get; set; }
        public int? BoxTranId { get; set; }
        public string BoxFrom { get; set; }
        public string Desca { get; set; }
        public string BoxTo { get; set; }
        public string Desce { get; set; }
        public decimal? Valu { get; set; }
    }
}
