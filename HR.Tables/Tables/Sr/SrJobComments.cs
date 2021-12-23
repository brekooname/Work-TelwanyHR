using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobComments
    {
        public int JobComentId { get; set; }
        public int? JorderId { get; set; }
        public int? EmpIdComBy { get; set; }
        public string Comment { get; set; }

        public virtual SrJobOrder Jorder { get; set; }
    }
}
