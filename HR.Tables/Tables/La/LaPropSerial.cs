using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class LaPropSerial
    {
        public int PropId { get; set; }
        public int? CustMain { get; set; }
        public int? CustProp { get; set; }
        public int? LandId { get; set; }

        public virtual MsCustomer CustMainNavigation { get; set; }
    }
}
