using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwHelpingAccountsSearch
    {
        public string AccountCode { get; set; }
        public string AccountNameA { get; set; }
        public string CustVendDesc { get; set; }
        public decimal? OpenningBalanceDepit { get; set; }
        public decimal? OpenningBalanceCredit { get; set; }
        public decimal? AccCurrTrancDepit { get; set; }
        public decimal? AccCurrTrancCredit { get; set; }
        public string CustVendDesc2 { get; set; }
        public string AccountDescription { get; set; }
    }
}
