using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR.BLL;
using HR.BLL.DTO;
using HR.Common;
using HR.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Controllers
{
    public class AccountController : Controller
    {
        AccountBll _accountBll;
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(AccountBll accountBll, IHttpContextAccessor httpContextAccessor)
        {
            _accountBll = accountBll;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            var action = _accountBll.WebLogIn(login, out int id);
            if (action.status == 200)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Path = "/";
                cookieOptions.Expires = DateTime.UtcNow.AddHours(HourServer.hours).AddYears(1);
                      Response.Cookies.Append(AppConstant.Cookies.userId, id + "",cookieOptions);
                return Redirect("/home/index");
            }
            ViewBag.message = action.message;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(AppConstant.Cookies.userId);
            return Redirect("/Account/Login");
        }
    }
}
