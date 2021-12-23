using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class QualityItemRecPackages
    {
        public int ItemRecPackId { get; set; }
        public int? ItemRecQualityId { get; set; }
        public int? WorkOrderId { get; set; }
        public string Code { get; set; }
        public int? PackageSerial { get; set; }
        public long? AlterSerial { get; set; }

        public virtual QualityItemRecCheck ItemRecQuality { get; set; }
        public virtual ProdWorkOrder WorkOrder { get; set; }
    }
}
