using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwCustomerCategory
    {
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public string CustomerDescE { get; set; }
        public bool? IsActive { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CatCode { get; set; }
        public string CatDescA { get; set; }
        public string CatDescE { get; set; }
    }
}
