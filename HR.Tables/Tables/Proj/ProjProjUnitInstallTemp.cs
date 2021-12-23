using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitInstallTemp
    {
        public int ProjUnitInstallTempId { get; set; }
        public int? ProjUnitId { get; set; }
        public int? InstallTempId { get; set; }

        public virtual CodInstallmentTemps InstallTemp { get; set; }
        public virtual ProjProjUnits ProjUnit { get; set; }
    }
}
