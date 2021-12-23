using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdBasicUnits
    {
        public ProdBasicUnits()
        {
            InverseParentUnitNavigation = new HashSet<ProdBasicUnits>();
            MsItemUnit = new HashSet<MsItemUnit>();
        }

        public int BasUnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitNam { get; set; }
        public string UnitNameE { get; set; }
        public decimal? UnittRate { get; set; }
        public string Symbol { get; set; }
        public int? ParentUnit { get; set; }
        public string Remarks { get; set; }
        public string AutoDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ProdBasicUnits ParentUnitNavigation { get; set; }
        public virtual ICollection<ProdBasicUnits> InverseParentUnitNavigation { get; set; }
        public virtual ICollection<MsItemUnit> MsItemUnit { get; set; }
    }
}
