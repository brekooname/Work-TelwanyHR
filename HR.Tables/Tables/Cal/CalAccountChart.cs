using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class CalAccountChart
    {
        public CalAccountChart()
        {
            CalAccChrtDailyAssist = new HashSet<CalAccChrtDailyAssist>();
            CalAccountClaasiJoin = new HashSet<CalAccountClaasiJoin>();
            CalAccountUsers = new HashSet<CalAccountUsers>();
            CalCostCenterAccount = new HashSet<CalCostCenterAccount>();
            CalEmpAccounts = new HashSet<CalEmpAccounts>();
            CodDailyAssistance = new HashSet<CodDailyAssistance>();
        }

        public int AccountId { get; set; }
        public long? AccountCode { get; set; }
        public string AccountNameA { get; set; }
        public string AccountNameE { get; set; }
        public int? MainAccountId { get; set; }
        public int? AccountLevel { get; set; }
        public byte? AccountType { get; set; }
        public byte? AccountNature { get; set; }
        public byte? AccountGroup { get; set; }
        public byte? AccCashFlow { get; set; }
        public bool? CalcMethod { get; set; }
        public int? CurrencyId { get; set; }
        public int? Aid { get; set; }
        public int? AccBulkAccount { get; set; }
        public int? AccountCategory { get; set; }
        public bool? CostCentersDistribute { get; set; }
        public bool? CurrencyReevaluation { get; set; }
        public bool? AccountStopped { get; set; }
        public string RemarksA { get; set; }
        public string RemarksE { get; set; }
        public decimal? OpenningBalanceDepit { get; set; }
        public decimal? OpenningBalanceCredit { get; set; }
        public decimal? AccCurrTrancDepit { get; set; }
        public decimal? AccCurrTrancCredit { get; set; }
        public decimal? AccTotalDebit { get; set; }
        public decimal? AccTotaCredit { get; set; }
        public decimal? BalanceDebitLocal { get; set; }
        public decimal? BalanceCreditLocal { get; set; }
        public decimal? OpenningBalanceDepitCurncy { get; set; }
        public decimal? OpenningBalanceCreditCurncy { get; set; }
        public decimal? AccCurrTrancDepitCurncy { get; set; }
        public decimal? AccCurrTrancCreditCurncy { get; set; }
        public decimal? AccTotalDebitCurncy { get; set; }
        public decimal? AccTotaCreditCurncy { get; set; }
        public decimal? BalanceDebitCurncy { get; set; }
        public decimal? BalanceCreditCurncy { get; set; }
        public decimal? AccApproxim { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public byte? CostCenterOption { get; set; }

        public virtual SysAnalyticalCodes A { get; set; }
        public virtual ICollection<CalAccChrtDailyAssist> CalAccChrtDailyAssist { get; set; }
        public virtual ICollection<CalAccountClaasiJoin> CalAccountClaasiJoin { get; set; }
        public virtual ICollection<CalAccountUsers> CalAccountUsers { get; set; }
        public virtual ICollection<CalCostCenterAccount> CalCostCenterAccount { get; set; }
        public virtual ICollection<CalEmpAccounts> CalEmpAccounts { get; set; }
        public virtual ICollection<CodDailyAssistance> CodDailyAssistance { get; set; }
    }
}
