using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR;
using HR.BLL;

using Microsoft.AspNetCore.Mvc;

namespace HRApp.Areas.Api
{
    [ApiController]
    [Route("api/[controller]/[Action]/{id?}")]
    public class FinancialReceivablesController : Controller
    {
        private readonly SalaryIssueBll _salaryIssueBll;
        public FinancialReceivablesController(SalaryIssueBll salaryIssueBll)
        {
            _salaryIssueBll = salaryIssueBll;
        }
        

        public object GetFinancialReceivables(int pageIndex=1, bool total = false)
        {

            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var emp = _salaryIssueBll.GetFinancialReceivables(int.Parse(userId), pageIndex, total);
            if (emp == null) return Unauthorized();
            return emp;


        }
        public object GetFinancialReceivableDetails(int SalaryIssuDocId, string langKey="ar")
        {

            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var emp = _salaryIssueBll.GetFinancialReceivableDetails(int.Parse(userId),SalaryIssuDocId,langKey );
            if (emp == null) return Unauthorized();
            return emp;


        }
    }
}
