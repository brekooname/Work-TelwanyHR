using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobFiles
    {
        public int FileId { get; set; }
        public int? JorderId { get; set; }
        public string FileName { get; set; }
        public string FileDesc { get; set; }
        public byte[] Image { get; set; }
        public byte[] Binary { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
