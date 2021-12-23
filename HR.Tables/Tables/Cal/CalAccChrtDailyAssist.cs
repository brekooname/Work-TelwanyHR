using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalAccChrtDailyAssist
    {
        public int AccChrtDailyAssistId { get; set; }
        public int? AccountId { get; set; }
        public int? DailyAssisId { get; set; }

        public virtual CalAccountChart Account { get; set; }
    }
}
