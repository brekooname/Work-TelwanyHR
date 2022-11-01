using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HR.Static;
using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Tables.Tables;

using Microsoft.EntityFrameworkCore;

using static System.Collections.Specialized.BitVector32;

namespace HR.BLL
{
    public class VacationBll
    {
        private IRepository<HrVacationRequest> _repHrVacationRequest;
        private IRepository<HrVacationDoc> _repHrVacationDoc;
        SettingBLL _settingBLL;

        public VacationBll(IRepository<HrVacationRequest> repHrVacationRequest, IRepository<HrVacationDoc> repHrVacationDoc, SettingBLL settingBLL)
        {
            _repHrVacationRequest = repHrVacationRequest;
            _repHrVacationDoc = repHrVacationDoc;
            _settingBLL = settingBLL;
        }

        public object Add(VacationRequestDTO mdl, string langKey)
        {
            var setting = _settingBLL.GetDefaultSetting();

            mdl.DayCount = (int)(mdl.ToDate - mdl.FromDate).TotalDays;
            var requests = _repHrVacationRequest.GetAll();
            int CurrentTrNo = 1;
            if(requests.Any())
             CurrentTrNo = requests.Max(x => x.TrNo) + 1;
            bool action = _repHrVacationRequest.Insert(new HrVacationRequest
            {
                EmpId = mdl.EmployeeId,
                VacationType = mdl.VacationType,
                FromDate = mdl.FromDate,
                ToDate = mdl.ToDate,
                DayCount = mdl.DayCount,
                Remarks1 = mdl.Note,
                TrDate = DateTime.UtcNow.AddHours(HourServer.hours),
                TrNo = CurrentTrNo,
                CreatedBy = mdl.EmployeeId.ToString(),
                CreatedAt = DateTime.UtcNow.AddHours(HourServer.hours),
                RequestImageUrl=mdl.ImageUrl,
                BookId = setting.DefVacReqBookId,
                TermId = setting.TermId,
                FinancialIntervalsId = setting.FinancialIntervalsId
            });
            return new
            {
                Status = action ? 200 : 500,
                message = action ? (langKey == "ar" ? "تم تقديم الطلب بنجاح" : "The request has been submitted successfully")

                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }


        public object Update(EditVacationRequestDTO mdl, string langKey)
        {
            mdl.DayCount = (int)(mdl.ToDate - mdl.FromDate).TotalDays;
            var entity = _repHrVacationRequest.Find(x => x.VacRequestId == mdl.VacationRequestId && x.EmpId == mdl.EmployeeId).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Status = 500,
                    message = (langKey == "ar" ? "بيانات غير صحيحة" : "Data Not Valid")
                };
            }
            entity.VacationType = mdl.VacationType;
            entity.FromDate = mdl.FromDate;
            entity.ToDate = mdl.ToDate;
            entity.DayCount = mdl.DayCount;
            entity.Remarks1 = mdl.Note;
            entity.UpdateAt = DateTime.UtcNow.AddHours(HourServer.hours);
            entity.UpdateBy = mdl.EmployeeId.ToString();
            if (mdl.ImageUrl != "")
            {
                entity.RequestImageUrl = mdl.ImageUrl;
            }

            bool action = _repHrVacationRequest.Update(entity);
            return new
            {
                Status = action ? 200 : 500,
                message = action ? (langKey == "ar" ? "تم تعديل الطلب بنجاح" : "The request has been Updated successfully")

                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }

        public object GetVacationRequestById(int userId, int id)
        {
            return _repHrVacationRequest.GetAll().Where(x => x.VacRequestId == id).
                ToList().
                Select(x => new
                {
                    id = x.VacRequestId,
                    FromDate = x.FromDate.Value.ToString("MM-dd-yyyy"),
                    ToDate = x.ToDate.Value.ToString("MM-dd-yyyy"),
                    VacationType = x.VacationType,
                    Remarks1 = x.Remarks1,
                    RequestImageUrl=x.RequestImageUrl
                }).FirstOrDefault();
        }

        public object EmployeeVacation(int EmployeeId, int pageIndex, bool total, string langKey)
        {
            var vacations = _repHrVacationDoc.GetAll().Where(x => x.EmpId == EmployeeId);
            var _count = vacations.Count();
            if (!total)
            {
                vacations = vacations.Skip((pageIndex - 1) * 10).Take(10);
            }

            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(_count) / 10),
                data = vacations.ToList().Select(x => new
                {
                    FromDate = x.FromDate.HasValue ? x.FromDate.Value.ToString("dd-MMMM-yyyy") : "",
                    ToDate = x.FromDate.HasValue ? x.ToDate.Value.ToString("dd-MMMM-yyyy") : "",
                    Date = (x.FromDate.HasValue ? x.FromDate.Value.ToString("dd-MMMM-yyyy") : "") + "  " + (x.FromDate.HasValue ? x.ToDate.Value.ToString("dd-MMMM-yyyy") : ""),
                    NetDaysCount = x.NetDaysCount ?? 0,
                    VacationType = GetVacationtypeAsString((VacationTypeEnum)x.VacationType, langKey),
                    VacationTypeId = x.VacationType
                })
            };
        }

        public string GetVacationtypeAsString(VacationTypeEnum Type, string langKey)
        {
            string _name = "";
            _name = Type switch
            {
                VacationTypeEnum.AnnualVacation => langKey == "ar" ? "سنوى" : "Annual Vacation",
                VacationTypeEnum.ReservedVacation => langKey == "ar" ? "عارضة" : "Reserved Vacation",
                VacationTypeEnum.Other => langKey == "ar" ? "أخرى" : "Other",
                _ => ""
            };
            return _name;
        }

        public object ManageVacationRequest(int id, bool accept, int userId, string langKey)
        {
            var entity = _repHrVacationRequest.GetById(id);
            if (entity == null)
                return new
                {
                    Status = 500,
                    message = (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            
            if (!accept)
            {
                entity.IsPosted = true;
                entity.PostedDate = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.Postedby = userId + "";
                bool action = _repHrVacationRequest.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? (langKey == "ar" ? "تم رفض الطلب بنجاح" : "The request has been rejected successfully")

             : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            }
            else
            {
                var query = _repHrVacationDoc.GetAll();
                if (query.Any(x => x.VacRequestId == entity.VacRequestId))
                {
                    return new
                    {
                        Status = 200,
                        message = (langKey == "ar" ? "تم قبول الطلب مسبقاً" : "the request has benn accepted")
                    };
                }
                int CurrentTrNo = query.Max(x => x.TrNo) + 1;
                bool action = _repHrVacationDoc.Insert(new HrVacationDoc
                {
                    VacRequestId=entity.VacRequestId,
                    EmpId = entity.EmpId,
                    VacationType = entity.VacationType,
                    FromDate = entity.FromDate,
                    ToDate = entity.ToDate,
                    DayCount = entity.DayCount,
                    Remarks1 = entity.Remarks1,
                    TrDate = DateTime.UtcNow.AddHours(HourServer.hours),
                    TrNo = CurrentTrNo,
                    CreatedBy = userId + "",
                    CreatedAt = DateTime.UtcNow.AddHours(HourServer.hours)
                });
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? (langKey == "ar" ? "تم قبول الطلب بنجاح" : "The request has been accepted successfully")

         : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            }
        }

        public int GetCount()  => _repHrVacationRequest.Find(x => !x.DeletedAt.HasValue).Count();

        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            string sql = @"select Hr_VacationRequest.VacRequestId as Id,Hr_Employees.Name1 as EmployeeArName,Hr_Employees.Name2 as EmployeeEnName,convert(varchar, Hr_VacationRequest.FromDate, 23) as FromDate
                        ,Hr_VacationRequest.CreatedAt ,convert(varchar, Hr_VacationRequest.ToDate, 23) as ToDate,Hr_VacationRequest.VacationType,Hr_VacationRequest.Remarks1,
                        Hr_VacationRequest.RequestImageUrl from Hr_VacationRequest 
                        join Hr_Employees on Hr_Employees.EmpId =Hr_VacationRequest.EmpId where Hr_VacationRequest.DeletedAt is null";
            List<VacationRequestMV> query = _repHrVacationRequest.ExecuteStoredProcedure<VacationRequestMV>(sql, null, System.Data.CommandType.Text).ToList();
            query.ForEach(x => x.VacationTypeStr = GetVacationtypeAsString((VacationTypeEnum)x.VacationType, "ar"));

            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.VacationTypeStr.ToLower().Contains(mdl.SSearch.ToLower())
            || x.EmployeeArName.ToLower().Contains(mdl.SSearch.ToLower())
            || x.EmployeeEnName.ToLower().Contains(mdl.SSearch.ToLower())
            )

            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList();
            return new DataTableResponse(total, _data.ToList());
        }
    }
}
