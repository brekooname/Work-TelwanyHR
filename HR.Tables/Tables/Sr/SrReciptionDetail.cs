using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrReciptionDetail
    {
        public int RecipDetlId { get; set; }
        public int? ReciptionId { get; set; }
        public string CustRequest { get; set; }
        public string Remarks { get; set; }
        public int? ComId { get; set; }
        public byte? Serial { get; set; }

        public virtual SrComplaints Com { get; set; }
        public virtual SrReciption Reciption { get; set; }
    }
}
