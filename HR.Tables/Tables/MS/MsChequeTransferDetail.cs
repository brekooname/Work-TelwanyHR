using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsChequeTransferDetail
    {
        public int ChequTranDetailId { get; set; }
        public int? RectId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? BalanceAfter { get; set; }
        public string Remarks { get; set; }
    }
}
