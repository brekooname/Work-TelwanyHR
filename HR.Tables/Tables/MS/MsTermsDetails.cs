using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsTermsDetails
    {
        public int TermDetailId { get; set; }
        public int? TermId { get; set; }
        public int? AccountIdDebit { get; set; }
        public byte? AccountDebitFixed { get; set; }
        public int? CostCenterIdDebit { get; set; }
        public byte? CostCenterDebitFixed { get; set; }
        public string ValuAccountDebit { get; set; }
        public int? AccountIdCredit { get; set; }
        public byte? AccountCreditFixed { get; set; }
        public int? CostCenterIdCredit { get; set; }
        public byte? CostCenterCreditFixed { get; set; }
        public string ValuAccountCredit { get; set; }
        public int? AccountIdDisc { get; set; }
        public byte? AccountDiscIsFixed { get; set; }
        public int? CostCenterIdDisc { get; set; }
        public byte? CostCenterDiscIsFixed { get; set; }
        public string ValuAccountDisc { get; set; }
        public int? AccountIdCash { get; set; }
        public byte? AccountCashIsFixed { get; set; }
        public int? CostCenterIdCash { get; set; }
        public byte? CostCenterCashIsFixed { get; set; }
        public string ValuAccountCash { get; set; }
        public int? AccountIdTax { get; set; }
        public byte? AccountTaxIsFixed { get; set; }
        public int? CostCenterIdTax { get; set; }
        public byte? CostCenterTaxIsFixed { get; set; }
        public string ValuAccountTax { get; set; }
        public bool? AccDiscDebitOrCredit { get; set; }
        public bool? AccCashDebitOrCredit { get; set; }
        public bool? AccTaxDebitOrCredit { get; set; }
        public int? AddAccountId1 { get; set; }
        public byte? AddAccount1IsFixed { get; set; }
        public int? AddCostCenterId1 { get; set; }
        public byte? AddCostCenter1IsFixed { get; set; }
        public string ValuAddAccount1 { get; set; }
        public int? AddAccountId2 { get; set; }
        public byte? AddAccountIsFixed2 { get; set; }
        public int? AddCostCenterId2 { get; set; }
        public byte? AddCostCenterIsFixed2 { get; set; }
        public string ValuAddAccount2 { get; set; }
        public int? AddAccountId3 { get; set; }
        public byte? AddAccountIsFixed3 { get; set; }
        public int? AddCostCenterId3 { get; set; }
        public byte? AddCostCenterIsFixed3 { get; set; }
        public string ValuAddAccount3 { get; set; }
        public int? AddAccountId4 { get; set; }
        public byte? AddAccountIsFixed4 { get; set; }
        public int? AddCostCenterId4 { get; set; }
        public byte? AddCostCenterIsFixed4 { get; set; }
        public string ValuAddAccount4 { get; set; }
        public int? AddAccountId5 { get; set; }
        public byte? AddAccountIsFixed5 { get; set; }
        public int? AddCostCenterId5 { get; set; }
        public byte? AddCostCenterIsFixed5 { get; set; }
        public string ValuAddAccount5 { get; set; }
        public bool? AddAcc1DebitOrCredit { get; set; }
        public bool? AddAcc2DebitOrCredit { get; set; }
        public bool? AddAcc3DebitOrCredit { get; set; }
        public bool? AddAcc4DebitOrCredit { get; set; }
        public bool? AddAcc5DebitOrCredit { get; set; }
        public bool? AnalaticalCodeMust { get; set; }

        public virtual MsTerms Term { get; set; }
    }
}
