using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCustomerBranches
    {
        public int CustBranchId { get; set; }
        public int? CustomerId { get; set; }
        public string CustBranchCode { get; set; }
        public string CustBranchName1 { get; set; }
        public string CustBranchName2 { get; set; }
        public string Remarks { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }

        public virtual MsCustomer Customer { get; set; }
    }
}
