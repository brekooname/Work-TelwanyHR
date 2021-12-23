using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using HR;
using HR.BLL;
using HR.BLL.DTO;

using Microsoft.AspNetCore.Mvc;

namespace HRApp.Areas.Api
{
    [ApiController]
    [Route("api/[controller]/[Action]/{id?}")]
    public class ManageController : Controller
    {
        private readonly EmployeeBll _employeeBll;
        public ManageController(EmployeeBll employeeBll)
        {
            _employeeBll = employeeBll;
        }


        public object PendingRequests(int pageIndex = 1, bool total = false, string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _employeeBll.GetPendingOrders(int.Parse(userId), langKey, pageIndex, total);
            return result;
        }

        public object AcceptRequest(int requestId, OrderTypeEnum requestType, bool Accept, string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _employeeBll.ManageRequests(int.Parse(userId), requestId, requestType, Accept, langKey);
            return result;
        }

    }
}
