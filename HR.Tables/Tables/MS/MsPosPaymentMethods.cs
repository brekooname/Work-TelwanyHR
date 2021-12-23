using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPosPaymentMethods
    {
        public int PayMethodId { get; set; }
        public decimal? AddPercent { get; set; }
        public byte[] MethodImage { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public bool? MandatoryFieldData { get; set; }
        public string UserQuestion { get; set; }
    }
}
