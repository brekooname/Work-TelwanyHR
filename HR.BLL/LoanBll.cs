using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HR.Static;
using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Static;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class LoanBll
    {
        private readonly IRepository<HrEmpLoanRequest> _repHrEmpLoanRequest;
        private readonly IRepository<HrEmpLoans> _repHrEmpLoans;
        SettingBLL _settingBLL;

        public LoanBll(IRepository<HrEmpLoanRequest> repHrEmpLoanRequest, IRepository<HrEmpLoans> repHrEmpLoans, SettingBLL settingBLL)
        {
            _repHrEmpLoanRequest = repHrEmpLoanRequest;
            _repHrEmpLoans = repHrEmpLoans;
            _settingBLL = settingBLL;
        }

        public object Add(LoanRequestDTO mdl, string langKey)
        {
            var setting = _settingBLL.GetDefaultSetting();
            var requests = _repHrEmpLoanRequest.GetAll();
            int CurrentTrNo = 1;
            if (requests.Any())
                CurrentTrNo = requests.Max(x => x.TrNo) + 1;
            bool action = _repHrEmpLoanRequest.Insert(new HrEmpLoanRequest
            {
                EmpId = mdl.EmployeeId,
                LoanValue = mdl.LoanValue,
                Installments = mdl.InstallmentsCount,
                InstallmentValue = mdl.InstallmentValue,
                LastInstallmentValue = (mdl.LoanValue - (mdl.InstallmentValue * mdl.InstallmentsCount)),
                Remarks1 = mdl.Note,
                TrDate = DateTime.UtcNow.AddHours(HourServer.hours),
                TrNo = CurrentTrNo,
                CreatedBy = mdl.EmployeeId.ToString(),
                CreatedAt = DateTime.UtcNow.AddHours(HourServer.hours),
                RequestImageUrl = mdl.ImageUrl,
                BookId = setting.DefLoanReqBookId,
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


        public object Update(EditLoanRequestDTO mdl, string langKey)
        {
            var entity = _repHrEmpLoanRequest.Find(x => x.EmpLoanReqId == mdl.LoanRequestId && x.EmpId == mdl.EmployeeId).FirstOrDefault();
            if (entity == null)
            {
                return new
                {
                    Status = 500,
                    message = (langKey == "ar" ? "بيانات غير صحيحة" : "Data Not Valid")
                };
            }
            entity.LoanValue = mdl.LoanValue;
            entity.Installments = mdl.InstallmentsCount;
            entity.InstallmentValue = mdl.InstallmentValue;
            entity.LastInstallmentValue = (mdl.LoanValue - (mdl.InstallmentValue * mdl.InstallmentsCount));
            entity.Remarks1 = mdl.Note;
            entity.UpdateAt = DateTime.UtcNow.AddHours(HourServer.hours);
            entity.UpdateBy = mdl.EmployeeId.ToString();
            if (mdl.ImageUrl != "")
            {
                entity.RequestImageUrl = mdl.ImageUrl;
            }

            bool action = _repHrEmpLoanRequest.Update(entity);
            return new
            {
                Status = action ? 200 : 500,
                message = action ? (langKey == "ar" ? "تم تعديل الطلب بنجاح" : "The request has been Updated successfully")

                : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
            };
        }

        public object GetLoanRequestById(int userId, int id)
        {
            return _repHrEmpLoanRequest.GetAll().Where(x => x.EmpLoanReqId == id).
                ToList().
                Select(x => new
                {
                    id = x.EmpLoanReqId,
                    LoanValue = Math.Round(x.LoanValue ?? 0, 2),
                    InstallmentValue = Math.Round(x.InstallmentValue ?? 0, 2),
                    InstallmentsCount = x.Installments,
                    Remarks1 = x.Remarks1,
                    RequestImageUrl = x.RequestImageUrl
                }).FirstOrDefault();
        }

        public object ManageLoanRequest(int id, bool accept, int userId, string langKey)
        {
            var entity = _repHrEmpLoanRequest.GetById(id);
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
                bool action = _repHrEmpLoanRequest.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? (langKey == "ar" ? "تم رفض الطلب بنجاح" : "The request has been rejected successfully")

             : (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                };
            }
            else
            {
                var query = _repHrEmpLoans.GetAll();
                if (query.Any(x => x.EmpLoanReqId == entity.EmpLoanReqId))
                {
                    return new
                    {
                        Status = 200,
                        message = (langKey == "ar" ? "تم قبول الطلب مسبقاً" : "the request has benn accepted")
                    };
                }
                // int CurrentTrNo = int.Parse(_repHrEmpLoans.GetAll().Max(x => x.ManualTrNo)) + 1;
                bool action = _repHrEmpLoans.Insert(new HrEmpLoans
                {
                    EmpLoanReqId = entity.EmpLoanReqId,
                    EmpId = entity.EmpId,
                    LoanValue = entity.LoanValue,
                    Installments = entity.Installments,
                    InstallmentValue = entity.InstallmentValue,
                    LastInstallmentValue = (entity.LoanValue - (entity.InstallmentValue * entity.Installments)),
                    Remarks1 = entity.Remarks1,
                    TrDate = DateTime.UtcNow.AddHours(HourServer.hours),
                    // ManualTrNo = CurrentTrNo + "",
                    CreatedBy = entity.EmpId + "",
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

        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            string sql = @"select Hr_EmpLoanRequest.EmpLoanReqId as Id,Hr_Employees.Name1 as EmployeeArName,Hr_Employees.Name2 as EmployeeEnName,Hr_EmpLoanRequest.CreatedAt,
                        Hr_EmpLoanRequest.InstallmentValue, Hr_EmpLoanRequest.Installments ,Hr_EmpLoanRequest.LoanValue, Hr_EmpLoanRequest.Remarks1,
                        Hr_EmpLoanRequest.RequestImageUrl from Hr_EmpLoanRequest 
                        join Hr_Employees on Hr_Employees.EmpId = Hr_EmpLoanRequest.EmpId where Hr_EmpLoanRequest.DeletedAt is null";

            List<LoanRequestMV> query = _repHrEmpLoanRequest.ExecuteStoredProcedure<LoanRequestMV>(sql, null, System.Data.CommandType.Text).ToList();

            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
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
