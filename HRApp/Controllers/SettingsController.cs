using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HR.Web.Helper;
using System.Text;
using System.IO;
using System;
using HR.DAL.Smtp;
using TimeZone = HR.Static.TimeZone;
using Nancy.Json;
using Nancy.Responses;
using System.Linq;
using System.Net;
using System.Net.Http;
using HR.Static;
using HR.BLL;
using HR.Tables.Tables;

namespace HRApp.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private AppSettingBll settingBll;
        public SettingsController(AppSettingBll settingBll)
        {
            this.settingBll = settingBll;
        }

        public IActionResult Index()
        {
            return View(settingBll.GetTimeZone());
        }

        [HttpPost]
        public IActionResult Index(AppSetting appSetting )
        {
            settingBll.SetTimeZone(appSetting);
            return RedirectToAction("index");
        }

        //public IActionResult Index()
        //{

        //    var json = SmtpConfig.GetTimeZone().ToString();
        //    Root timeZones = JsonConvert.DeserializeObject<Root>(json);
        //    return View(timeZones);
        //}
    }

}
