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
                TrDate = DateTime.UtcNow.AddHours(3),
                TrNo = CurrentTrNo,
                CreatedBy = mdl.EmployeeId.ToString(),
                CreatedAt = DateTime.UtcNow.AddHours(3),
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
            entity.UpdateAt = DateTime.UtcNow.AddHours(3);
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
                entity.PostedDate = DateTime.UtcNow.AddHours(3);
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
                    TrDate = DateTime.UtcNow.AddHours(3),
                    // ManualTrNo = CurrentTrNo + "",
                    CreatedBy = entity.EmpId + "",
                    CreatedAt = DateTime.UtcNow.AddHours(3)
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
