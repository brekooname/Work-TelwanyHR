using System;
using System.Collections.Generic;
using System.Text;
using HR.Static;
using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class TechnicalSupportBll
    {
        private readonly IRepository<Mobile_TechnicalSupport> _repTechnicalSupport;

        public TechnicalSupportBll(IRepository<Mobile_TechnicalSupport> repTechnicalSupport)
        {
            _repTechnicalSupport = repTechnicalSupport;
        }

        public object Add(TechnicalSupportDTO mdl, string langKey)
        {

            bool action = _repTechnicalSupport.Insert(new Mobile_TechnicalSupport { 
             Emp_Id=mdl.EmployeeId,
            Problem=mdl.Problem,
            TrDate=DateTime.UtcNow.AddHours(HourServer.hours)
            });
            return new
            {
                Status = action ? 200 : 500,
                message = action ?(langKey=="ar" ?"تم ارسال الشكوى  بنجاح" :"The complaint has been sent successfully")
                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }
    }
}
