using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsPosItemCategory
    {
        public int PosItemCategoryId { get; set; }
        public int? ItemCategoryId { get; set; }
        public bool? UseItemName { get; set; }
        public bool? UseItemImg { get; set; }
        public bool? UseItemCode { get; set; }
        public bool? UseItemBarcode { get; set; }
    }
}
