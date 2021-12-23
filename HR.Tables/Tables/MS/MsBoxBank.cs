using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsBoxBank
    {
        public MsBoxBank()
        {
            MsBoxCurrency = new HashSet<MsBoxCurrency>();
            MsBoxUsers = new HashSet<MsBoxUsers>();
            MsPaymentNote = new HashSet<MsPaymentNote>();
            MsReceiptNote = new HashSet<MsReceiptNote>();
            MsStores = new HashSet<MsStores>();
        }

        public int BoxId { get; set; }
        public string BoxCode { get; set; }
        public string Desca { get; set; }
        public string Desce { get; set; }
        public int? AccountId { get; set; }
        public int? StoreId { get; set; }
        public string KeeperName { get; set; }
        public string BankResposableName { get; set; }
        public string BankTel { get; set; }
        public string BankMobile { get; set; }
        public string BankFax { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBank { get; set; }
        public int? CheckPrintId { get; set; }
        public bool? ForAdjustOnly { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsBoxCurrency> MsBoxCurrency { get; set; }
        public virtual ICollection<MsBoxUsers> MsBoxUsers { get; set; }
        public virtual ICollection<MsPaymentNote> MsPaymentNote { get; set; }
        public virtual ICollection<MsReceiptNote> MsReceiptNote { get; set; }
        public virtual ICollection<MsStores> MsStores { get; set; }
    }
}
