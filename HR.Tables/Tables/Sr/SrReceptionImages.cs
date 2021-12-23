using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrReceptionImages
    {
        public int RecImgId { get; set; }
        public int? ReciptionId { get; set; }
        public byte[] Image { get; set; }
        public string ImgDesc { get; set; }

        public virtual SrReciption Reciption { get; set; }
    }
}
