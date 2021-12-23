using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsBoxCurrency
    {
        public int BoxCurrencyId { get; set; }
        public int? CurrencyId { get; set; }
        public int? BoxId { get; set; }
        public int? AccountId { get; set; }
        public int? AccountChrtId { get; set; }
        public int? RetAccountId { get; set; }
        public int? BankExpensAccId { get; set; }
        public int? ChequndercollectId { get; set; }

        public virtual MsBankAccount Account { get; set; }
        public virtual MsBoxBank Box { get; set; }
        public virtual MsCurrency Currency { get; set; }
    }
}
