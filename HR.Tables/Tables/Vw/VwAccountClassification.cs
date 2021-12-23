using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwAccountClassification
    {
        public long? Code { get; set; }
        public string DescA { get; set; }
        public string DescE { get; set; }
        public string ClassLevel { get; set; }
        public long? AccountCatCode { get; set; }
        public string AccountCatDescA { get; set; }
        public string AccountCatDescE { get; set; }
        public byte? AccountClassType { get; set; }
    }
}
