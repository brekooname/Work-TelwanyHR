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
    public class AppSettingController : ControllerBase
    {
        private readonly AppSettingBll Service;
        public AppSettingController(AppSettingBll service)
        {
            Service = service;
        }

        public object Find(string productKey, string LangKey="ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = Service.Find(productKey, LangKey);
            return result;
        }
    }
}
