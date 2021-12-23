using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class GUserScreenFields
    {
        public int ScreenFieldId { get; set; }
        public int? UserModuleId { get; set; }
        public int? UserId { get; set; }
        public int? UserGroupId { get; set; }
        public string FieldName { get; set; }
        public string AuthDesc { get; set; }
        public bool? Authinticated { get; set; }
        public int? AuthenticatedBy { get; set; }
    }
}
