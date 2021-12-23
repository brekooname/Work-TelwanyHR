using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjectItemEmpJoin
    {
        public ProjProjectItemEmpJoin()
        {
            ProjProjItemEmpTaskJoin = new HashSet<ProjProjItemEmpTaskJoin>();
        }

        public int ProjItemEmpId { get; set; }
        public int? ProjItemsJoinId { get; set; }
        public int? EmpId { get; set; }

        public virtual HrEmployees Emp { get; set; }
        public virtual ProjProjectItemsJoin ProjItemsJoin { get; set; }
        public virtual ICollection<ProjProjItemEmpTaskJoin> ProjProjItemEmpTaskJoin { get; set; }
    }
}
