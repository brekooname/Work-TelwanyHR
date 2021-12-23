using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class VwAllCostCenterTransactions
    {
        public int PostQueId { get; set; }
        public int? CostCenterId { get; set; }
        public bool? IsHelpCostCenter { get; set; }
        public string HelpCostCenterType { get; set; }
        public int? TermId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Rate { get; set; }
        public string TableCode { get; set; }
        public int? TableEntityId { get; set; }
        public decimal? DebitLocal { get; set; }
        public decimal? CreditLocal { get; set; }
        public decimal? DebitCurrency { get; set; }
        public decimal? CreditCurrency { get; set; }
        public bool? IsPosted { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerDescA { get; set; }
        public int? CostCenterCode { get; set; }
        public string CostCenterNameA { get; set; }
        public decimal? OpenningBalanceDepitCurncy { get; set; }
        public decimal? OpenningBalanceCreditCurncy { get; set; }
        public decimal? OpenningBalanceDepit { get; set; }
        public decimal? OpenningBalanceCredit { get; set; }
        public decimal? CostCenterCurrTrancDepit { get; set; }
        public decimal? CostCenterTotaCredit { get; set; }
        public decimal? BalanceDebitLocal { get; set; }
        public decimal? BalanceCreditLocal { get; set; }
        public decimal? CostCenterCurrTrancDepitCurncy { get; set; }
        public decimal? CostCenterCurrTrancCreditCurncy { get; set; }
        public decimal? CostCenterTotalDebitCurncy { get; set; }
        public decimal? CostCenterTotaCreditCurncy { get; set; }
        public decimal? BalanceDebitCurncy { get; set; }
        public decimal? BalanceCreditCurncy { get; set; }
        public int? CustomerId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescA { get; set; }
        public decimal? CostCenterTotalDebit { get; set; }
        public string Remarks { get; set; }
        public decimal? BalanceLocalAfterDebit { get; set; }
        public decimal? BalanceLocalAfterCredit { get; set; }
        public decimal? BalanceCurrencyAfterDebit { get; set; }
        public decimal? BalanceCurrencyAfterCredit { get; set; }
        public bool? IsOpenning { get; set; }
        public bool? DefualtCurrency { get; set; }
        public string PrefixCode { get; set; }
        public string BookNameAr { get; set; }
        public string DocTrNo { get; set; }
    }
}
