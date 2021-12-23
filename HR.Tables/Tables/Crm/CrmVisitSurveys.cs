using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CrmVisitSurveys
    {
        public int VisitSurveyId { get; set; }
        public int? VisitId { get; set; }
        public int? SurveyId { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public bool? AnswerYorN { get; set; }
        public string FilePath { get; set; }

        public virtual CrmVisits Visit { get; set; }
    }
}
