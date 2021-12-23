using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrSegments
    {
        public int SegmentId { get; set; }
        public int? SalaryTypId { get; set; }
        public byte? SegmentSerial { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public decimal? FromSegmant { get; set; }
        public decimal? ToSegmant { get; set; }
        public decimal? SegmantPercent { get; set; }
        public string Remarks { get; set; }

        public virtual HrSalaryTypes SalaryTyp { get; set; }
    }
}
