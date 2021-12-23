using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsBankAccount
    {
        public MsBankAccount()
        {
            MsBoxCurrency = new HashSet<MsBoxCurrency>();
        }

        public int AccountId { get; set; }
        public string AcountCode { get; set; }
        public string AcounntNameA { get; set; }
        public string AcounntNameE { get; set; }

        public virtual ICollection<MsBoxCurrency> MsBoxCurrency { get; set; }
    }
}
