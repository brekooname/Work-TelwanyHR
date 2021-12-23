using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class QualityItemDeliveryPackages
    {
        public int ItemDeliceryPackId { get; set; }
        public int? ItemDeliverId { get; set; }
        public string Code { get; set; }
        public int? PackageSerial { get; set; }
        public long? AlterSerial { get; set; }

        public virtual QualityItemDelivery ItemDeliver { get; set; }
    }
}
