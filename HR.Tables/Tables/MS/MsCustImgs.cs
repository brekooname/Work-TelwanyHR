using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCustImgs
    {
        public int CustImgId { get; set; }
        public int? CustomerId { get; set; }
        public byte[] Image { get; set; }
        public string ImgDesc1 { get; set; }
        public string ImgDesc2 { get; set; }

        public virtual MsCustomer Customer { get; set; }
    }
}
