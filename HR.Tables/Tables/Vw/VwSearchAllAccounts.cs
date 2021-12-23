using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwSearchAllAccounts
    {
        public string AccountCode { get; set; }
        public string AccountNameA { get; set; }
        public int? AccountLevel { get; set; }
        public bool? CalcMethod { get; set; }
        public int AccType { get; set; }
        public string AccDesc { get; set; }
        public decimal? BalanceDebitCurncy { get; set; }
        public decimal? BalanceCreditCurncy { get; set; }
        public byte? AccountType { get; set; }
        public byte? AccountNature { get; set; }
        public byte? AccountGroup { get; set; }
        public byte? AccCashFlow { get; set; }
        public string AccDesc2 { get; set; }
        public string AccountDescription { get; set; }
    }
}
