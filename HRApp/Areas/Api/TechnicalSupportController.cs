using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR;
using HR.BLL;
using HR.BLL.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Areas.Api
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class TechnicalSupportController : ControllerBase
    {
        private readonly TechnicalSupportBll _technicalSupportBll;
        public TechnicalSupportController(TechnicalSupportBll technicalSupportBll)
        {
            _technicalSupportBll = technicalSupportBll;
        }

        [HttpPost]
        public object Request([FromBody] TechnicalSupportDTO mdl,string LangKey="ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            mdl.EmployeeId = int.Parse(userId);
            var result = _technicalSupportBll.Add(mdl, LangKey);

            return result;

        }
    }
}
