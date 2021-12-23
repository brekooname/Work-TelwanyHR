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
    public class HomeController : Controller
    {
        private readonly AccountBll _accountBll;
        public HomeController(AccountBll accountBll)
        {
            _accountBll = accountBll;
      
        }
        [HttpPost]
        public object Dashboard(string langKey = "ar")
        {

            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var emp = _accountBll.GetDashboardData(int.Parse(userId), langKey);
            if (emp == null) return Unauthorized();
            return emp;


        }
    }
}
