using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsCustomerTypes
    {
        public MsCustomerTypes()
        {
            MsCustomer = new HashSet<MsCustomer>();
        }

        public int CustomerTypeId { get; set; }
        public string CustomerTypeCode { get; set; }
        public string CustomerTypeDescA { get; set; }
        public string CustomerTypeDescE { get; set; }
        public int? CustomerTypeParent { get; set; }
        public int? CustomerTypeLevel { get; set; }
        public byte? CustomerTypeLevelType { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<MsCustomer> MsCustomer { get; set; }
    }
}
