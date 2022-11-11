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
    public class ReportsController : Controller
    {
        ReportsBLL _reportsBLL;
        public ReportsController(ReportsBLL reportsBLL)
        {
            _reportsBLL = reportsBLL;
        }

        public object DelayReport(int reportType=1,int pageIndex = 1, string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _reportsBLL.GetDelayReport(langKey, pageIndex, reportType);

            return result;
        }

        public object DelayDetailsReport(int pageIndex = 1)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _reportsBLL.GetDelayDetailsReport(pageIndex);

            return result;
        }
    }
}
