using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class LeavPermisionBll
    {
        private IRepository<HrLeavPermissionRequest> _repLeavPermision;
        private IRepository<HrLeavePermision> _repLeavPermisionDoc;
        SettingBLL _settingBLL;
        public LeavPermisionBll(IRepository<HrLeavPermissionRequest> repLeavPermision, IRepository<HrLeavePermision> repLeavPermisionDoc,
            SettingBLL settingBLL)
        {
            _repLeavPermision = repLeavPermision;
            _repLeavPermisionDoc = repLeavPermisionDoc;
            _settingBLL = settingBLL;
        }

        public object Add(LeavPermisionDTO mdl, string langKey)
        {
            var setting = _settingBLL.GetDefaultSetting();
        
            var requests = _repLeavPermision.GetAll();
            int CurrentTrNo = 1;
            if (requests.Any())
                CurrentTrNo = requests.Max(x => x.TrNo) + 1;

            bool action = _repLeavPermision.Insert(new HrLeavPermissionRequest
            {
                EmpId = mdl.EmployeeId,
                FromDate = mdl.Date,
                ToDate = mdl.Date,
                TrNo=CurrentTrNo,
                FromTime = mdl.Date + mdl.FromTime,
                ToTime = mdl.Date + mdl.ToTime,
                HoursCount = (mdl.ToTime - mdl.FromTime).Hours,
                TrDate = DateTime.UtcNow.AddHours(3),
                DayCount = 1,
                Remarks1 = mdl.Note,
                CreatedAt = DateTime.UtcNow.AddHours(3),
                CreatedBy = mdl.EmployeeId.ToString(),
                RequestImageUrl=mdl.ImageUrl,
                BookId= setting.DefPermReqBookId,
                TermId= setting.TermId,
                FinancialIntervalsId=setting.FinancialIntervalsId
            });
            return new
            {
                Status = action ? 200 : 500,
                message = action ? (langKey == "ar" ? "تم تقديم الطلب بنجاح" : "The request has been submitted successfully")

                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }


        public object Update(EditLeavPermisionDTO mdl, string langKey)
        {
            var entity = _repLeavPermision.Find(x => x.LeavPermReqId == mdl.leavePremisionId && x.EmpId == mdl.EmployeeId).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Status = 500,
                    message = (langKey == "ar" ? "بيانات غير صحيحة" : "Data Not Valid")
                };
            }
            entity.FromDate = mdl.Date;
            entity.ToDate = mdl.Date;
            entity.FromTime = mdl.Date + mdl.FromTime;
            entity.ToTime = mdl.Date + mdl.ToTime;
            entity.HoursCount = (mdl.ToTime - mdl.FromTime).Hours;
            entity.Remarks1 = mdl.Note;
            entity.UpdateAt = DateTime.UtcNow.AddHours(3);
            entity.UpdateBy = mdl.EmployeeId.ToString();
            if (mdl.ImageUrl!="")
            {
                entity.RequestImageUrl = mdl.ImageUrl;
            }

            bool action = _repLeavPermision.Update(entity);
            return new
            {
                Status = action ? 200 : 500,
                message = action ? (langKey == "ar" ? "تم تعديل الطلب بنجاح" : "The request has been Updated successfully")

                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }

        public object GetLeavePremisionById(int userId, int id)
        {
            return _repLeavPermision.GetAll().Where(x => x.LeavPermReqId == id).ToList().Select(x => new
                {
                    id = x.LeavPermReqId,
                    FromDate = x.FromDate.Value.ToString("MM-dd-yyyy"),
                    ToDate = x.ToDate.Value.ToString("MM-dd-yyyy"),
                    FromTime = x.FromTime.Value.ToString("HH:mm"),
                    ToTime = x.ToTime.Value.ToString("HH:mm"),
                    Remarks1 = x.Remarks1,
                    RequestImageUrl =  x.RequestImageUrl
                }).FirstOrDefault();
        }


        public object ManageLeavePermisionRequest(int id, bool accept, int userId, string langKey)
        {
            var entity = _repLeavPermision.GetById(id);
            if (entity == null)
                return new
                {
                    Status = 500,
                    message = (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };

            if (!accept)
            {
                entity.IsPosted = true;
                entity.PostedDate = DateTime.UtcNow.AddHours(3);
                entity.Postedby = userId + "";
                bool action = _repLeavPermision.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? (langKey == "ar" ? "تم رفض الطلب بنجاح" : "The request has been rejected successfully")

             : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            }
            else
            {
                var query = _repLeavPermisionDoc.GetAll();
                if(query.Any(x=>x.LeavPermReqId==entity.LeavPermReqId))
                {
                    return new
                    {
                        Status = 200,
                        message = (langKey == "ar" ? "تم قبول الطلب مسبقاً" : "the request has benn accepted")
                    };
                }
                int CurrentTrNo =query.Max(x => x.TrNo) + 1;
                bool action = _repLeavPermisionDoc.Insert(new HrLeavePermision
                {
                    LeavPermReqId=entity.LeavPermReqId,
                    EmpId = entity.EmpId,
                    FromDate = entity.FromDate,
                    ToDate = entity.ToDate,
                    FromTime =  entity.FromTime,
                    ToTime =  entity.ToTime,
                    HoursCount = entity.HoursCount,
                    TrDate = DateTime.UtcNow.AddHours(3),
                    DayCount = 1,
                    Remarks1 = entity.Remarks1,
                    CreatedAt = DateTime.UtcNow.AddHours(3),
                    CreatedBy = entity.EmpId+""
                });
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? (langKey == "ar" ? "تم قبول الطلب بنجاح" : "The request has been accepted successfully")

         : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            }
        }


    }
}
