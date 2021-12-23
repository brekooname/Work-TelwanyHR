using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysNaming
    {
        public int NamingId { get; set; }
        public string Culture { get; set; }
        public string Screen { get; set; }
        public string CtrlName { get; set; }
        public string CtrlOriginalText { get; set; }
        public string CtrlNewText { get; set; }
        public string CtrlTextBefore { get; set; }
        public int? UserId { get; set; }
        public bool? IsAllUsers { get; set; }
        public bool? HasFlexFields { get; set; }
        public string FlexMasterCardTable { get; set; }
        public string SelectedField { get; set; }
        public bool? MustSelect { get; set; }
        public bool? Hidden { get; set; }
        public int? CtrlLocationX { get; set; }
        public int? CtrlLocationY { get; set; }
        public bool? CtrlParentIsTpl { get; set; }
        public string CtrlParent { get; set; }
        public string CtrlParentType { get; set; }
        public string CtrlType { get; set; }
        public bool? IsDropDown { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
