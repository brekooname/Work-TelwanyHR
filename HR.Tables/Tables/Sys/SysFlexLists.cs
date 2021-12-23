using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SysFlexLists
    {
        public int FlexListId { get; set; }
        public int? NamingId { get; set; }
        public string FlexCode { get; set; }
        public string FlexName1 { get; set; }
        public string FlexName2 { get; set; }
        public string TableCode { get; set; }
        public string FieldCode { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public bool? Enabled { get; set; }
        public string Culture { get; set; }
        public bool? AllLanguages { get; set; }
    }
}
