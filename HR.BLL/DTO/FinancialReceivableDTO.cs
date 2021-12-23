using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class FinancialReceivableDTO
    {
        public DateTime TrDate { get; set; }
        public int SalaryIssuDocId { get; set; }
        public int Total { get; set; }
        public decimal NetValue { get; set; }
        public decimal RoundNetValue
        {
            get
            {
                return Math.Round(NetValue, 2);
            }
        }
        public string SubPeriodCodeAndDate { get; set; }
        public string Code
        {
            get
            {
                if (SubPeriodCodeAndDate != null && SubPeriodCodeAndDate != "")
                    return SubPeriodCodeAndDate.Split("*_*")[0];
                else
                    return "";
            }
        }
        public string Date
        {
            get
            {
                if (SubPeriodCodeAndDate != null && SubPeriodCodeAndDate != "")
                    return SubPeriodCodeAndDate.Split("*_*")[1];
                else
                    return "";
            }
        }
    }
    public class FinancialReceivableDetailDTO
    {
        public decimal? AddValue { get; set; }
        public decimal? DeductValue { get; set; }
        public decimal? OtherValue { get; set; }
        public decimal? NetValue { get; set; }
        public string SalaryTypeName { get; set; }
    }
}
