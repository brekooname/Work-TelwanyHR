using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsVendorBranches
    {
        public int VendBranchId { get; set; }
        public int? VendorId { get; set; }
        public string VendBranchCode { get; set; }
        public string VendBranchName1 { get; set; }
        public string VendBranchName2 { get; set; }
        public string Remarks { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }

        public virtual MsVendor Vendor { get; set; }
    }
}
