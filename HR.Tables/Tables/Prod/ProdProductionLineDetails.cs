using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProdProductionLineDetails
    {
        public int ProdLineDetailId { get; set; }
        public int? ProLineId { get; set; }
        public int? TaskId { get; set; }
        public decimal? TimeBeforFormat { get; set; }
        public byte? TimeUnit { get; set; }
        public decimal? Minutes { get; set; }
        public decimal? Hours { get; set; }
        public decimal? Days { get; set; }
        public decimal? Months { get; set; }
        public string Remarks { get; set; }

        public virtual ProdProductionLine ProLine { get; set; }
    }
}
