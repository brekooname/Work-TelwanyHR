using System;
using System.Collections.Generic;
using System.Linq;
using HR.Static;
using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Static;
using HR.Tables.Tables;

using Microsoft.EntityFrameworkCore;

using static System.Collections.Specialized.BitVector32;

namespace HR.BLL
{

    public class EmployeeBll
    {
        private IRepository<HrEmployees> _rep;
        private IRepository<GUsers> _repUsers;
        private IRepository<HrEmpShift> _repHrEmpShift;
        private IRepository<HrEmpStore> _repHrEmpStore;
        private IRepository<HrEmpLocations> _repHrEmpLocations;
        private IRepository<Mobile_Message> _repMobile_Message;
        VacationBll _VacationBll;
        LoanBll _LoanBll;
        LeavPermisionBll _LeavPermisionBll;
  
        public EmployeeBll(IRepository<HrEmployees> rep, IRepository<Mobile_Message> repMobile_Message
            ,VacationBll vacationBll,LoanBll loanBll,LeavPermisionBll leavPermisionBll, IRepository<HrEmpShift> repHrEmpShift, IRepository<HrEmpStore> repHrEmpStore,
            IRepository<HrEmpLocations> repHrEmpLocations, IRepository<GUsers> repUsers)
        {
            _rep = rep;
            _repMobile_Message = repMobile_Message;
            _VacationBll = vacationBll;
            _LoanBll = loanBll;
            _LeavPermisionBll = leavPermisionBll;
            _repHrEmpShift = repHrEmpShift;
            _repHrEmpStore = repHrEmpStore;
            _repHrEmpLocations = repHrEmpLocations;
            _repUsers = repUsers;

        }

        public HrEmployees GetById(int id)
            => _rep.GetAll().Include(x => x.Job).FirstOrDefault(x => x.EmpId == id);

        public object getEmployeesNotHaveUser(int ?id=null)
        {
            var users = _repUsers.GetAll();
            var res  = _rep.GetAll().Where(x => !users.Any(y => y.EmpId == x.EmpId) || (id.HasValue && x.EmpId == id.Value)).Select(x => new { Id = x.EmpId, Name = x.Name1 }).ToList();
            return res;
        }

        public object GetEmployeeOrders(int EmployeeId, string LanguageKey, int pageIndex = 1, bool total = false)
        {
            var data = _rep.ExecuteStoredProcedure<EmployeeOrdersDTO>("Hr_GetOrders",
                      new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=EmployeeId,ParameterName="@EmployeeId"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=total,ParameterName="@total"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=(pageIndex-1)*10,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=10,ParameterName="@Length"}
            });
            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(data.FirstOrDefault()?.Total ?? 0) / 10),
                data = data.ToList().Select(x => new
                {
                    Id = x.Id,
                    RequestCode = x.TrNo ?? "",
                    RequestTypeNAme = GetTypeName(LanguageKey, Enum.Parse<OrderTypeEnum>(x.Type)),
                    Status = (int)Enum.Parse<StatusEnum>(x.StatusKey),
                    StatusName = GetStatusName(LanguageKey, Enum.Parse<StatusEnum>(x.StatusKey)),
                    Date = (x.TrDate.HasValue ? x.TrDate.Value.ToString("dd-MMMM-yyyy") : ""),
                    TypeKey = x.Type,
                    TypeValue = (int)Enum.Parse<OrderTypeEnum>(x.Type)
                    ,
                    RequestImageUrl = x.RequestImageUrl
                })
            };
        }

        public object ManageRequests(int userId, int requestId, OrderTypeEnum requestType, bool accept, string langKey)
        {
            switch (requestType)
            {
                case OrderTypeEnum.Vacation:
                    return _VacationBll.ManageVacationRequest(requestId, accept, userId, langKey);
                    break;
                case OrderTypeEnum.Loan:
                    return _LoanBll.ManageLoanRequest(requestId, accept, userId, langKey);
                    break;
                case OrderTypeEnum.LeavePermision:
                    return _LeavPermisionBll.ManageLeavePermisionRequest(requestId, accept, userId, langKey);
                    break;
                default:
                      return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? "حدث خطأ ما اعد المحاولة" : "An error has occurred")
                    };

                    break;
            }

          
        }

        public object GetPendingOrders(int EmployeeId, string LanguageKey, int pageIndex = 1, bool total = false)
        {
            var data = _rep.ExecuteStoredProcedure<EmployeeOrdersDTO>("Hr_GetPendingOrders",
                      new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=total,ParameterName="@total"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=(pageIndex-1)*10,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=10,ParameterName="@Length"}
            });
            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(data.FirstOrDefault()?.Total ?? 0) / 10),
                data = data.ToList().Select(x => new
                {
                    Id = x.Id,
                    RequestCode = x.TrNo ?? "",
                    RequestTypeNAme = GetTypeName(LanguageKey, Enum.Parse<OrderTypeEnum>(x.Type)),
                    Status = (int)Enum.Parse<StatusEnum>(x.StatusKey),
                    StatusName = GetStatusName(LanguageKey, Enum.Parse<StatusEnum>(x.StatusKey)),
                    Date = (x.TrDate.HasValue ? x.TrDate.Value.ToString("dd-MMMM-yyyy") : ""),
                    TypeKey = x.Type,
                    TypeValue = (int)Enum.Parse<OrderTypeEnum>(x.Type),
                    EmployeeName = x.Name1
                })
            };
        }


        public string GetTypeName(string langKey, OrderTypeEnum typeEnum)
        {
            string Name = "";
            bool IsArabic = langKey == "ar";
            switch (typeEnum)
            {
                case OrderTypeEnum.Vacation:
                    Name = IsArabic ? "طلب اجازة" : "Vacation Request";
                    break;
                case OrderTypeEnum.Loan:
                    Name = IsArabic ? "طلب سلفة" : "Loan Request";
                    break;
                case OrderTypeEnum.LeavePermision:
                    Name = IsArabic ? "طلب اذن انصراف" : "Leave Permision Request";
                    break;
                default:
                    Name = "";
                    break;
            }
            return Name;
        }

        public string GetStatusName(string langKey, StatusEnum typeEnum)
        {
            string Name = "";
            bool IsArabic = langKey == "ar";
            switch (typeEnum)
            {
                case StatusEnum.accepted:
                    Name = IsArabic ? " مقبول" : "Accept";
                    break;
                case StatusEnum.rejected:
                    Name = IsArabic ? " مرفوض" : "Rejected";
                    break;
                case StatusEnum.pending:
                    Name = IsArabic ? " معلق " : "Pending";
                    break;
                default:
                    Name = "";
                    break;
            }
            return Name;
        }

        public object GetMessages(int EmployeeId, int pageIndex = 1)
        {

            var data = _repMobile_Message.GetAll().Where(x=>x.Emp_Id==EmployeeId);
            var Total = data.Count();
            data = data.OrderByDescending(x => x.TrDate).Skip((pageIndex - 1) * 10).Take(10);


            return new
            {
                pagesCount = (int)Math.Ceiling((double)Total / 10),
                data = data.ToList().Select(x => new
                {
                    x.Message,
                    Date = x.TrDate.Value.ToString("dd-MM-yyyyy")
                })
            };
        }


        public object Add(HrEmployees mdl)
        {
            if (string.IsNullOrEmpty(mdl.EmpCode) || string.IsNullOrEmpty(mdl.Name1) || !mdl.Gender.HasValue)
                return new
                {
                    Status = 500,
                    message = "الحقول المطلوبة الكود - الاسم - النوع"
                };

            var entity = _rep.Find(x => x.EmpCode == mdl.EmpCode).FirstOrDefault();
            if (entity == null)
            {
                var action = _rep.Insert(mdl);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الاضافة بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
            {
                return new
                {
                    Status = 500,
                    message = "هذا الكود موجود مسبقاً"
                };
            }
        }


        public object AddUser(GUsers mdl)
        {
            if (string.IsNullOrEmpty(mdl.UserCode) || string.IsNullOrEmpty(mdl.FirstName) || string.IsNullOrEmpty(mdl.Password) 
                || string.IsNullOrEmpty(mdl.UserName)||!mdl.UserType.HasValue||!mdl.EmpId.HasValue )
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repUsers.Find(x => x.UserCode == mdl.UserCode).FirstOrDefault();
            if (entity == null)
            {
                var action = _repUsers.Insert(mdl);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الاضافة بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
            {
                return new
                {
                    Status = 500,
                    message = "هذا الكود موجود مسبقاً"
                };
            }
        }


        public object EditUser(GUsers mdl)
        {
            if (string.IsNullOrEmpty(mdl.UserCode) || string.IsNullOrEmpty(mdl.FirstName) || string.IsNullOrEmpty(mdl.Password)
                         || string.IsNullOrEmpty(mdl.UserName) || !mdl.UserType.HasValue || !mdl.EmpId.HasValue) return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repUsers.GetById(mdl.UserId);
            if (entity != null)
            {
                entity.EmpId = mdl.EmpId;
                entity.UserCode = mdl.UserCode;
                entity.FirstName = mdl.FirstName;
                entity.LastName = mdl.LastName;
                entity.UserName = mdl.UserName;
                entity.UserType = mdl.UserType;
                entity.Password = mdl.Password;
                entity.MacAddress = mdl.MacAddress;
               

              
                var action = _repUsers.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم التعديل بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
                return new
                {
                    Status = 500,
                    message = "حدث خطأ ما اعد المحاولة"
                };

        }


        public object Edit(HrEmployees mdl)
        {
            if (string.IsNullOrEmpty(mdl.EmpCode) || string.IsNullOrEmpty(mdl.Name1) || !mdl.Gender.HasValue)
                return new
                {
                    Status = 500,
                    message = "الحقول المطلوبة الكود - الاسم - النوع"
                };

            var entity = _rep.GetById(mdl.EmpId);
            if (entity != null)
            {
                entity.EmpCode = mdl.EmpCode;
                entity.Name1 = mdl.Name1;
                entity.JobId = mdl.JobId;
                entity.DailyCost = mdl.DailyCost;
                entity.HourlyCost = mdl.HourlyCost;
                entity.TotalDailyCost = mdl.TotalDailyCost;
                entity.TotalHourlyCost = mdl.TotalHourlyCost;
                entity.Gender= mdl.Gender;
                entity.Salary = mdl.Salary;
                entity.Phone1 = mdl.Phone1;
                entity.Email = mdl.Email;
                entity.Phone2 = mdl.Phone2;
                entity.Remarks = mdl.Remarks;
                if (!string.IsNullOrEmpty(mdl.ImageUrl))
                    entity.ImageUrl = mdl.ImageUrl;

                _repHrEmpShift.DeleteRangeWithoutSaveChange(_repHrEmpShift.Find(x => x.EmpId == entity.EmpId));
                _repHrEmpStore.DeleteRangeWithoutSaveChange(_repHrEmpStore.Find(x => x.EmpId == entity.EmpId));
                _repHrEmpLocations.DeleteRangeWithoutSaveChange(_repHrEmpLocations.Find(x => x.EmpId == entity.EmpId));

                if (mdl.HrEmpStores != null && mdl.HrEmpStores.Any())
                    _repHrEmpStore.InsertRangeWithoutSaveChange(mdl.HrEmpStores.Select(x => new HrEmpStore
                {
                    EmpId = entity.EmpId,
                    StoreId = x.StoreId
                }));

                if (mdl.HrEmpShifts != null && mdl.HrEmpShifts.Any())
                    _repHrEmpShift.InsertRangeWithoutSaveChange(mdl.HrEmpShifts.Select(x => new HrEmpShift
                {
                    EmpId = entity.EmpId,
                    ShiftId = x.ShiftId
                }));

                if (mdl.HrEmpLocations != null && mdl.HrEmpLocations.Any())

                    _repHrEmpLocations.InsertRangeWithoutSaveChange(mdl.HrEmpLocations.Select(x => new HrEmpLocations
                {
                    EmpId = entity.EmpId,
                    LocationId = x.LocationId
                }));

                var action = _rep.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم التعديل بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
                return new
                {
                    Status = 500,
                    message = "حدث خطأ ما اعد المحاولة"
                };

        }

        public object DisplayDataForEdit(int id)
        {
            return _rep.GetAll().Include(x=>x.HrEmpShifts).Include(x=>x.HrEmpStores).Include(x=>x.HrEmpLocations).Where(x => x.EmpId == id)
                .Select(x => new { Stores = x.HrEmpStores.Select(x => x.StoreId).ToList(),
                    Shifts= x.HrEmpShifts.Select(x=>x.ShiftId).ToList(),
                    locations = x.HrEmpLocations.Select(x=>x.LocationId).ToList(),
                    Gender=x.Gender.ToString().ToLower(), x.JobId, x.Name1,x.EmpCode,x.EmpId,x.Phone2,x.Salary ,x.DailyCost,x.HourlyCost,x.TotalDailyCost,x.TotalHourlyCost, x.Phone1 ,x.Email,x.Remarks}).FirstOrDefault();
        }

        
        public object DisplayUserDataForEdit(int id)
        {
            return _repUsers.GetAll().Where(x => x.UserId == id)
                .Select(x => new { x.UserId,x.FirstName,x.LastName,x.UserName,x.UserType,x.Password,x.EmpId,x.UserCode,x.MacAddress}).FirstOrDefault();
        }


        public object Delete(int id)
        {
            var entity = _rep.GetById(id);
            if (entity != null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.DeletedBy = "1";
                var action = _rep.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الحذف بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            return new
            {
                Status = 500,
                message = "حدث خطأ ما اعد المحاولة"
            };
        }
        public object DeleteUser(int id)
        {
            var entity = _repUsers.GetById(id);
            if (entity != null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.DeletedBy = "1";
                var action = _repUsers.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الحذف بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            return new
            {
                Status = 500,
                message = "حدث خطأ ما اعد المحاولة"
            };
        }

        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            var query = _rep.GetAll().Include(x=>x.Shift).Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.Name1.ToLower().Contains(mdl.SSearch.ToLower())
            || x.EmpCode.ToLower().Contains(mdl.SSearch.ToLower()))

            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
                name = x.Name1,
                code = x.EmpCode,
                id = x.EmpId,
                Gender=  x.Gender.Value?"انثى":"ذكر"
            });
            return new DataTableResponse(total, _data.ToList());
        }
            public DataTableResponse LoadUsersData(DataTableDTO mdl)
        {
            var query = _repUsers.GetAll().Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.FirstName.ToLower().Contains(mdl.SSearch.ToLower())
            || x.LastName.ToLower().Contains(mdl.SSearch.ToLower())
            || x.UserCode.ToLower().Contains(mdl.SSearch.ToLower())
            || x.UserName.ToLower().Contains(mdl.SSearch.ToLower())
            )

            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
               x.FirstName,
               x.LastName,
               x.UserName,
               x.UserCode,
                UserType= x.UserType==0?"مستخدم":x.UserType==2?"مدير ":x.UserType==5?"مدير موارد بشرية":"",
                id=x.UserId
            });
            return new DataTableResponse(total, _data.ToList());
        }

        public object GetItemByIndex(int index)
        {
            var query = $@" select * from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
from [dbo].[Hr_Employees] t where DeletedAt is null )ww

where rowNum={index} 
";
            var data = _rep.ExecuteStoredProcedure<HrEmployees>
                (query, null, System.Data.CommandType.Text).Select(x => new {
                    Stores =_repHrEmpStore.GetAll().Where(z=>z.EmpId==x.EmpId).Select(xz => xz.StoreId).ToList(),
                    Shifts = _repHrEmpShift.GetAll().Where(z => z.EmpId == x.EmpId).Select(xz => xz.ShiftId).ToList(),
                    locations = _repHrEmpLocations.GetAll().Where(z => z.EmpId == x.EmpId).Select(xz => xz.LocationId).ToList(),
                    Gender = x.Gender.ToString().ToLower(),
                    x.JobId,
                    x.Name1,
                    x.EmpCode,
                    x.EmpId,
                    x.Phone2,
                    x.Salary,
                    x.DailyCost,
                    x.HourlyCost,
                    x.TotalDailyCost,
                    x.TotalHourlyCost,
                    x.Phone1,
                    x.Email,
                    x.Remarks
                }).FirstOrDefault();

            return (data);
        }

        public object GetUserItemByIndex(int index)
        {
            var query = $@" select * from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
from [dbo].[G_Users] t where DeletedAt is null )ww

where rowNum={index} 
";
            var data = _rep.ExecuteStoredProcedure<GUsers>
              (query, null, System.Data.CommandType.Text).Select(x => new
              {
                  x.UserId,
                  x.FirstName,
                  x.LastName,
                  x.UserName,
                  x.UserType,
                  x.Password,
                  x.EmpId,
                  x.UserCode,
                  x.MacAddress
              }).FirstOrDefault();

            return (data);
        }

        public int GetCount()
          => _rep.Find(x => !x.DeletedAt.HasValue).Count();

        public int GetUsersCount()
  => _repUsers.Find(x => !x.DeletedAt.HasValue).Count();


    }
}
