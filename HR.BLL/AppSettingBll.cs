using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.BLL.DTO;
using HR.DAL;
using HR.Static;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class AppSettingBll
    {
        private readonly IRepository<AppSetting> Service;
        public AppSettingBll(IRepository<AppSetting> service)
        {
            Service = service;
        }

        public AppSetting GetTimeZone()
        {
            try
            {
                AppSetting app = Service.GetAllAsNoTracking().FirstOrDefault();
                HourServer.hours = app.TimeZone.Value;
                return app;
            }
            catch
            {
                HourServer.hours = 0;
                return null;
            }
        }

        public bool SetTimeZone(AppSetting appSetting)
        {
            try
            {
                bool result =  Service.Update(appSetting);
                Service.SaveChange();
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
