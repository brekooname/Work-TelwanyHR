using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsGaShipmentDetail
    {
        public int ShipMentDetailId { get; set; }
        public int ShipMentId { get; set; }
        public int? LetterExportId { get; set; }
        public int? Serial { get; set; }
        public string MotorSn { get; set; }
        public string BodySn { get; set; }
        public int? MororId { get; set; }
        public int? CityId { get; set; }
        public int? CapcityId { get; set; }
        public int? MachineId { get; set; }
        public byte? BasicSaleType { get; set; }
        public string Remarks { get; set; }
        public string Model { get; set; }

        public virtual MsGaLetterExport LetterExport { get; set; }
        public virtual MsGaShipment ShipMent { get; set; }
    }
}
