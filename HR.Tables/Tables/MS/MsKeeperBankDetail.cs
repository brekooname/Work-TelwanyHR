using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsKeeperBankDetail
    {
        public int KeeperDetailId { get; set; }
        public int? KeeperId { get; set; }
        public int? RectId { get; set; }
        public bool? IsCollected { get; set; }
        public DateTime? CollectDate { get; set; }
        public bool? IsReturned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Remarks { get; set; }
        public bool? IsTransferred { get; set; }
        public DateTime? TransferredAte { get; set; }

        public virtual MsKeeperBank Keeper { get; set; }
    }
}
