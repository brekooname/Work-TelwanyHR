using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR;
using HR.BLL;
using HR.BLL.DTO;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HR.BLL.AccountBll;

namespace HRApp.Areas.Api
{
    [ApiController]
    [Route("api/[controller]/[Action]/{id?}")]
    public class AccountController : ControllerBase
    {
        private readonly AccountBll _accountBll;
        private readonly EmployeeBll _employeeBll;

        public AccountController(AccountBll accountBll, EmployeeBll employeeBll)
        {
            _accountBll = accountBll;
            _employeeBll = employeeBll;
        }

        [HttpPost, AllowAnonymous]
        public object Login([FromBody] LoginDTO mdl)
        {
            if (mdl.UserName.IsEmpty())
            {
                return new { status = 500, Token = "", Message = "ادخل اسم المستخدم" };
            }
            else if (mdl.Password.IsEmpty())
            {
                return new { status = 500, Token = "", Message = "ادخل كلمة السر" };
            }
            string token = _accountBll.LogIn(mdl, out int userType, out string error, out string logo);

            if (token.IsEmpty()) return new { status = 500, Token = "", Message = "  تأكد من اسم المستخدم وكلمة السر" };
            if (!error.IsEmpty()) return new { status = 500, Token = "", Message = error };

            return new
            {
                status = 200,
                UserType = userType,
                UserTypeName = userType == 0 ? "User" : userType == 2 ? "Manager" : userType == 5 ? "Hr" : "",
                Token = token,
                Message = "تم تسجيل الدخول بنجاح",
                Logo = logo
            };
        }

        [HttpGet, AllowAnonymous]
        public object Companies()
        {
            return _accountBll.Companies();
        }

        [HttpGet, AllowAnonymous]
        public object CompanyData(long CompanyId)
        {
            return _accountBll.CompanyData(CompanyId);
        }

        [HttpPost]
        public object GetProfileData(string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var emp = _accountBll.GetProfileData(int.Parse(userId), langKey);
            if (emp == null) return Unauthorized();
            return emp;

        }

        public object GetEmployeeOrders(string langKey = "ar", int pageIndex = 1, bool total = false)
        {

            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var emp = _employeeBll.GetEmployeeOrders(int.Parse(userId), langKey, pageIndex, total);
            if (emp == null) return Unauthorized();
            return emp;


        }

        [HttpPost]
        public object ScanQRIn([FromBody] Point point, [FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _accountBll.CheckQR(point, int.Parse(userId), langKey, true);
            return result;
        }

        [HttpPost]
        public object ScanQROut([FromBody] Point point, [FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _accountBll.CheckQR(point, int.Parse(userId), langKey, false);
            return result;
        }

        [HttpPost]
        public object ScanQRAsString(string point, [FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _accountBll.CheckQR(point, int.Parse(userId), langKey);
            return result;
        }

        [HttpPost]
        public object CheckFingerprintIn([FromBody] Point point, [FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _accountBll.CheckQR(point, int.Parse(userId), langKey, true, false);
            return result;
        }

        [HttpPost]
        public object CheckFingerprintOut([FromBody] Point point, [FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _accountBll.CheckQR(point, int.Parse(userId), langKey, false, false);
            return result;
        }

        [HttpPost]
        public object Messages(int pageIndex = 1)
        {

            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();
            var result = _employeeBll.GetMessages(int.Parse(userId), pageIndex);
            return result;
        }
    }
}
