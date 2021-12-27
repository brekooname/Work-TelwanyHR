using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.BLL.DTO;
using HR.DAL;
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

        public object Find(string productKey, string langKey)
        {
            try
            {
                AppSetting app = Service.Find(x => x.ProductKey == productKey).FirstOrDefault();

                return new
                {
                    Status = 200,
                    message = app == null ? (langKey == "ar" ? "لا توجد بيانات لهذه البيانات" : "There is no data for this data") 
                    : langKey == "ar" ? "تمت العمليه بنجاح" : "operation accomplished successfully",
                    Url = app?.Url
                };
            }
            catch
            {
                return new
                {
                    Status = 500,
                    message = langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred",
                    Url="",
                };
            }
        }
    }
}
