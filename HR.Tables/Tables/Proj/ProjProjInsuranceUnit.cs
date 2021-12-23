using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjInsuranceUnit
    {
        public int ProjInsuranceUnitId { get; set; }
        public int? ProjUnitId { get; set; }
        public int? InsurCaseId { get; set; }
        public int? UnitInsurstatId { get; set; }
        public int? InsurCovTypeId { get; set; }
        public decimal? InsuranceValue { get; set; }

        public virtual CodInsuranceCases InsurCase { get; set; }
        public virtual ProjProjUnits ProjUnit { get; set; }
        public virtual CodUnitInsuranceStatus UnitInsurstat { get; set; }
    }
}
