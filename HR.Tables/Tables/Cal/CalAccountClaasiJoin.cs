using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalAccountClaasiJoin
    {
        public int AcChrtJoinClaasi { get; set; }
        public int? AccountId { get; set; }
        public int? AccountClassId { get; set; }
        public byte? Operator { get; set; }
        public int? DaysCount { get; set; }
        public byte? TypeOfAcc { get; set; }

        public virtual CalAccountChart Account { get; set; }
    }
}
