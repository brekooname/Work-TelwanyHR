using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrPrograms
    {
        public SrPrograms()
        {
            SrTripProgramJoin = new HashSet<SrTripProgramJoin>();
        }

        public int ProgramId { get; set; }
        public string ProgramCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Days { get; set; }
        public string Mtscruze { get; set; }
        public byte? Number { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SrTripProgramJoin> SrTripProgramJoin { get; set; }
    }
}
