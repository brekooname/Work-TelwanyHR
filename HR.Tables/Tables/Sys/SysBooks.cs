using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysBooks
    {
        public int BookId { get; set; }
        public string PrefixCode { get; set; }
        public string BookNameAr { get; set; }
        public string BookNameEn { get; set; }
        public byte? TermType { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public bool? AutoSerial { get; set; }
        public bool? SystemIssuedOnly { get; set; }
        public bool? IsDefault { get; set; }
        public int? StartNum { get; set; }
        public int? EndNum { get; set; }
        public byte? PostType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
