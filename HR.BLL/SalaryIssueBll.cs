using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;

using Microsoft.EntityFrameworkCore;

namespace HR.BLL
{
    public class SalaryIssueBll
    {
        private readonly IRepository<HrSalaryIssueDoc> _repSalaryIssueDoc;
        private readonly IRepository<HrSalaryTypes> _repSalaryTypes;
        public SalaryIssueBll(IRepository<HrSalaryIssueDoc> repSalaryIssueDoc, IRepository<HrSalaryTypes> repSalaryTypes)
        {
            _repSalaryIssueDoc = repSalaryIssueDoc;
            _repSalaryTypes = repSalaryTypes;
        }

      
        public object GetFinancialReceivables(int EmployeeId, int pageIndex=1, bool total = false)
        {

            var data = _repSalaryIssueDoc.ExecuteStoredProcedure<FinancialReceivableDTO>("[dbo].[Hr_GetFinancialReceivables]",
                new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=EmployeeId,ParameterName="@EmployeeId"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=total,ParameterName="@total"},
                 new Microsoft.Data.SqlClient.SqlParameter{Value=(pageIndex-1)*10,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=10,ParameterName="@Length"}
            });
       

            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(data.FirstOrDefault()?.Total ?? 0) / 10),
                data = data.ToList().Select(x => new
                {
                    Id = x.SalaryIssuDocId,
                    NetValue = x.RoundNetValue,
                    Date = x.Date,
                    Code = x.Code
                })
            };
        }

    

        public object GetFinancialReceivableDetails(int EmployeeId, int SalaryIssuDocId, string langKey)
        {
            var data = _repSalaryIssueDoc.ExecuteStoredProcedure<FinancialReceivableDetailDTO>("[dbo].[Hr_GetFinancialReceivableDetails]", new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=EmployeeId,ParameterName="@EmplyeeID"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=langKey,ParameterName="@langKey"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=SalaryIssuDocId,ParameterName="@SalaryIssuDocId"}
            });

            var _AddValues = data.Where(x => x.AddValue != null).Select(x => new
            {
                Value = Math.Round(x.AddValue ?? 0, 2),
                SalaryTypeName = x.SalaryTypeName
            });

            var _DeductValues = data.Where(x => x.DeductValue != null).Select(x => new
            {
                Value = Math.Round(x.DeductValue ?? 0, 2),
                SalaryTypeName = x.SalaryTypeName
            });

            var _OtherValue = data.Where(x => x.OtherValue != null).Select(x => new
            {
                Value = Math.Round(x.DeductValue ?? 0, 2),
                SalaryTypeName = x.SalaryTypeName
            });

            return new
            {
                AddValues = _AddValues,
                TotalOfAddValues = _AddValues.Sum(x => x.Value),
                DeductValues = _DeductValues,
                TotalOfDeductValues = _DeductValues.Sum(x => x.Value),
                OtherValue = _OtherValue,
                TotalOfOtherValue = _OtherValue.Sum(x => x.Value),
                NetValue = Math.Round(data.FirstOrDefault()?.NetValue ?? 0, 2)
            };
        }
    }
}
