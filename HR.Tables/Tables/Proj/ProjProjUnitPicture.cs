using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjUnitPicture
    {
        public int ProjUnitPictureId { get; set; }
        public Guid Fsid { get; set; }
        public int? ProjUnitId { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string AttachPath { get; set; }
        public byte[] Fdata { get; set; }

        public virtual ProjProjUnits ProjUnit { get; set; }
    }
}
