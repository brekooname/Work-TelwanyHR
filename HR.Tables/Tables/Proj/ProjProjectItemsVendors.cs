using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjectItemsVendors
    {
        public int ProjectItemsVendorId { get; set; }
        public int? ProjectItemsId { get; set; }
        public int? VendorId { get; set; }
        public byte? VendorRate { get; set; }

        public virtual ProjProjectItems ProjectItems { get; set; }
        public virtual MsVendor Vendor { get; set; }
    }
}
