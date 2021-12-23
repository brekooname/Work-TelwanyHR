using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CrmSurvey
    {
        public int SurveyId { get; set; }
        public int VisitTypeId { get; set; }
        public int? UserRoleId { get; set; }
        public string VisitCode { get; set; }
        public string VisitName1 { get; set; }
        public string VisitName2 { get; set; }
        public byte? AnswerType { get; set; }
        public string AddField1 { get; set; }
        public string AddField2 { get; set; }
        public string AddField3 { get; set; }
        public string AddField4 { get; set; }
        public string AddField5 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual CrmVisitTypes VisitType { get; set; }
    }
}
