using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsGaMotorSndetail
    {
        public int MotorSearialId { get; set; }
        public int? MotorDocId { get; set; }
        public int? LetterNormId { get; set; }
        public int? LetterFayumId { get; set; }
        public int? MororId { get; set; }
        public int? CityId { get; set; }
        public int? CapcityId { get; set; }
        public int? MachineId { get; set; }
        public string MotorSn { get; set; }
        public string BodySn { get; set; }
        public string Remarks { get; set; }
        public byte? BasicSaleType { get; set; }
        public bool? LetterType { get; set; }
        public string Model { get; set; }

        public virtual MsGaLetterFayum LetterFayum { get; set; }
        public virtual MsGaLetterNormal LetterNorm { get; set; }
        public virtual MsGaMotorSn MotorDoc { get; set; }
    }
}
