using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjItemEmpTaskJoin
    {
        public int ProjItemEmpTaskId { get; set; }
        public int? ProjItemEmpId { get; set; }
        public int? TaskId { get; set; }
        public decimal? ExpectItemPercent { get; set; }
        public decimal? ExpectItemValue { get; set; }
        public decimal? ActualItemPercentExpense { get; set; }
        public decimal? ActualItemExpenseValue { get; set; }
        public decimal? FinishPercent { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual ProjProjectItemEmpJoin ProjItemEmp { get; set; }
        public virtual ProdTasks Task { get; set; }
    }
}
