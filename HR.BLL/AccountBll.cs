using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ClosedXML.Excel;
using HR.BLL.DTO;
using HR.BLL.Helper;
using HR.Common;
using HR.DAL;
using HR.Static;
using HR.Tables.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using ZXing;
using ZXing.Common;
using ZXing.Rendering;

using static HR.BLL.AccountBll;

using Point = HR.BLL.DTO.Point;



namespace HR.BLL
{
    public class AccountBll
    {
        private readonly IJwtAuthentication _jwtAuthentication;
        private readonly IRepository<MsCompany> _repCompany;
        private readonly IRepository<HrEmpKPIS> _repKPISEmployee;
        private readonly IRepository<GUsers> _repUser;
        private readonly IRepository<Mobile_Attendance> _repMobile_Attendance;
        private readonly IRepository<MsStores> _msStores;
        private readonly IRepository<HrLocation> _hrLocation;
        private readonly IRepository<HrEmpShift> _repHrEmpShift;
        private readonly IRepository<HrEmpStore> _repHrEmpStore;
        private readonly IRepository<HrEmpLocations> _repHrEmpLocations;

        #region BLL
        private EmployeeBll _employeeBll;
        #endregion
        public AccountBll(IRepository<GUsers> repUser, IRepository<MsCompany> repCompany,
            IJwtAuthentication jwtAuthentication,
            EmployeeBll employeeBll, IRepository<Mobile_Attendance> repMobile_Attendance, IRepository<HrEmpShift> repHrEmpShift,
            IRepository<HrEmpStore> repHrEmpStore, IRepository<HrEmpLocations> repHrEmpLocations, IRepository<HrEmpKPIS> repKPISEmployee,
            IRepository<MsStores> msStores , IRepository<HrLocation> hrLocation)
        {
            _repMobile_Attendance = repMobile_Attendance;
            _repUser = repUser;
            _employeeBll = employeeBll;
            _jwtAuthentication = jwtAuthentication;
            _repHrEmpShift = repHrEmpShift;
            _repHrEmpStore = repHrEmpStore;
            _repHrEmpLocations = repHrEmpLocations;
            _repKPISEmployee = repKPISEmployee;
            _repCompany = repCompany;
            _msStores = msStores;
            _hrLocation = hrLocation;
        }

        public string GetLogo()
        {
            var logo = "";
            if (_repCompany.GetAll().Any())
                logo = "/Upload/" + _repCompany.GetAll().FirstOrDefault().LogoUrl;
            return logo;
        }

        public object Companies()
        {
            SqlConnection con = new SqlConnection(@"Data Source=sql5108.site4now.net,1433,1433;Initial Catalog=DB_A44DA5_HrCompaniesDB;User Id=DB_A44DA5_HrCompaniesDB_admin;Password=A271185b;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand c = new SqlCommand($"select * from CompanyDetails  ", con);
            c.CommandType = System.Data.CommandType.Text;
            SqlDataReader read = c.ExecuteReader();
            List<object> Companies = new List<object>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Companies.Add(
                        new
                        {
                            CompanyId = read["CompanyId"].ToString(),
                            CompanyName = read["CompanyName"].ToString()
                        }
                       );
                }
            }
            return Companies;
        }

        public object CompanyData(long CompanyId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=sql5108.site4now.net,1433,1433;Initial Catalog=DB_A44DA5_HrCompaniesDB;User Id=DB_A44DA5_HrCompaniesDB_admin;Password=A271185b;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand c = new SqlCommand($"select * from CompanyDetails where CompanyId='{CompanyId}' ", con);
            c.CommandType = System.Data.CommandType.Text;
            SqlDataReader read = c.ExecuteReader();
            List<object> Companies = new List<object>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Companies.Add(
                        new
                        {
                            CompanyId = read["CompanyId"].ToString(),
                            CompanyName = read["CompanyName"].ToString(),
                            Logo = read["ImageUrl"].ToString(),
                            BaseUrl = read["BaseUrl"].ToString()
                        }
                       );
                }
            }
            return Companies.FirstOrDefault();
        }

        public string LogIn(LoginDTO mdl, out int userType, out string error, out string logo)
        {
            var user = _repUser.GetAll().FirstOrDefault(x => x.UserName.ToLower() == mdl.UserName.ToLower() && x.Password == mdl.Password
            && x.DeletedAt == null && x.DeletedBy == null);

            userType = 0; error = ""; logo = "";
            if (_repCompany.GetAll().Any())
                logo = "/Upload/" + _repCompany.GetAll().FirstOrDefault()?.LogoUrl ?? "";
            if (user != null)
            {
                if (user.MacAddress.IsEmpty())
                {
                    user.MacAddress = mdl.MacAddress;
                    _repUser.Update(user);
                }
                else if (user.MacAddress != mdl.MacAddress)
                {
                    error = "توجة لقسم ال hr";
                }

                if (user.UserType == 0 && user?.EmpId != null)
                {
                    userType = user.UserType.Value;
                    return _jwtAuthentication.Authenticate(user.EmpId.Value + "");
                }
                else if (user.UserType != 0)
                {
                    userType = user.UserType.Value;
                    return _jwtAuthentication.Authenticate(user.EmpId.Value + "");
                    //return _jwtAuthentication.Authenticate(user.UserId + "");
                }
            }
            return "";
        }

        public DataTableResponse LoadAttendanceData(DataTableDTO mdl)
        {
            var query = _repMobile_Attendance.GetAll().Where(x => (!mdl.dateFrom.HasValue || x.TrDate.Value.Date >= mdl.dateFrom.Value.Date)
            && (!mdl.dateTo.HasValue || x.TrDate.Value.Date <= mdl.dateTo.Value.Date)).Include(x => x.HrEmployees).Include(x => x.MsStores).Include(x => x.HrShifts);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty() || x.HrEmployees.EmpCode.ToLower().Contains(mdl.SSearch.ToLower())
            || x.HrEmployees.Name1.ToLower().Contains(mdl.SSearch.ToLower())));

             data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.AttendanceId),
                SortingDir.Desc => data.OrderByDescending(x => x.AttendanceId),
                _ => data
            };

            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
                // التعديل الذي تم اضافته علشان اقدر امسك السجل الخاص بالحضور والانصراف
                id = x.AttendanceId,
                name = x.HrEmployees != null ? x.HrEmployees.Name1 : "",
                code = x.HrEmployees != null ? x.HrEmployees.EmpCode : "",
                Store = x.MsStores != null ? x.MsStores.StoreDescA : "",
                Date = x.TrDate.HasValue ? x.TrDate.Value.ToString("dd-MM-yyyy HH:mm") : "",
                Status = x.Status,
                InOrOut = x.In.Value ? "حضور" : "انصراف",
                locationName = x.LocationName
            });

            return new DataTableResponse(total, _data.ToList());
        }

        public FileResult LoadAttendanceDataToExel(DataTableDTO mdl)
        {
            var query = _repMobile_Attendance.GetAll().Where(x => (!mdl.dateFrom.HasValue || x.TrDate.Value.Date >= mdl.dateFrom.Value.Date)
            && (!mdl.dateTo.HasValue || x.TrDate.Value.Date <= mdl.dateTo.Value.Date)).Include(x => x.HrEmployees).Include(x => x.MsStores).Include(x => x.HrShifts);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty() || x.HrEmployees.EmpCode.ToLower().Contains(mdl.SSearch.ToLower())
            || x.HrEmployees.Name1.ToLower().Contains(mdl.SSearch.ToLower())));

            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.AttendanceId),
                SortingDir.Desc => data.OrderByDescending(x => x.AttendanceId),
                _ => data
            };

            string FileName = "SoftGo_Report.xlsx";

            return GenerateExel(FileName, data);
        }

        private FileResult GenerateExel(string fileName , IEnumerable<Mobile_Attendance> attendances)
        {
            DataTable dataTable = new DataTable("attendances");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("حضور/إنصرف"),
                new DataColumn("الموقع"),
                new DataColumn("الفرع"),
                new DataColumn("الوقت"),
                new DataColumn("الاسم"),
                new DataColumn("الكود"),

            });

            foreach (var attendance in attendances)
            {
                dataTable.Rows
                    .Add(attendance.In.Value ? "حضور" : "انصراف",
                         attendance.LocationName,
                         attendance.MsStores.StoreDescA,
                         attendance.TrDate.Value.ToString("dd-MM-yyyy HH:mm"),
                         attendance.HrEmployees.Name1,
                         attendance.HrEmployees.EmpCode
                         
                          );
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                 wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var fileResult = new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = fileName
                    };

                    return fileResult;
                }
            }

        }


        public string GetUserData(int id)
        {
            return _repUser.Find(x => x.UserId == id).Select(x => new { Name = x.FirstName + " " + x.LastName }).Select(x => x.Name).FirstOrDefault();
        }

        public loginResponseDTO WebLogIn(LoginDTO mdl, out int id)
        {
            id = 0;

            if (string.IsNullOrEmpty(mdl.UserName))
                return new loginResponseDTO
                {
                    status = 500,
                    message = "ادخل اسم المستخدم"
                };

            if (string.IsNullOrEmpty(mdl.Password))
                return new loginResponseDTO
                {
                    status = 500,
                    message = "ادخل  كلمة السر"
                };

            var user = _repUser.GetAll().FirstOrDefault(x => x.UserName.ToLower() == mdl.UserName.ToLower() && x.Password == mdl.Password
            && x.DeletedAt == null && x.DeletedBy == null);

            if (user != null)
            {
                id = user.UserId;
                return new loginResponseDTO { status = 200, message = "تم التسجيل بنجاح" };
            }
            else
            {
                return new loginResponseDTO { status = 500, message = "تأكد من اسم المستخدم وكلمة السر  " };
            }
        }

        public object GetProfileData(int EmpId, string langKey)
        {
            var employee = _employeeBll.GetById(EmpId);
            if (employee == null)
                return null;
            return new
            {
                Status = 200,
                Name = langKey == "ar" ? employee.Name1 ?? "" : employee.Name2 ?? "",
                ContractStartDate = employee.ContractSrtDate.HasValue ? employee.ContractSrtDate.Value.ToString("dd/MM/yyyy") : "",
                Phone = employee.Phone1 ?? "",
                Address = langKey == "ar" ? employee.Address1 ?? "" : employee.Address1 ?? "",
                Job = (employee.Job != null) ? (langKey == "ar" ? employee.Job.Jname1 ?? "" : employee.Job.Jname1 ?? "") : "",
                AnnualVacsBalance = employee.AnnualVacsBalance ?? 0,
                ReservedVacsBalance = employee.ReservedVacsBalance ?? 0,
                Salary = 0
            };
        }

        public object GetDashboardData(int EmpId, string langKey)
        {
            //var employee2 = _employeeBll.GetById(userId);
            //var user = _repUser.GetById(userId);
            //if (user == null)
            //    return null;

            //if (user.EmpId == null)
            //    return null;

            //int EmpId = user.EmpId.Value;

            var employee = _employeeBll.GetById(EmpId);
            if (employee == null)
                return null;

            #region Calc KPIS

            int KPISValue = 0;

            var employeeKPIS = _repKPISEmployee.GetAll().Where(x => x.EmpId == EmpId);

            if (employeeKPIS.Any())
            {
                KPISValue = (int)Math.Floor((decimal)employeeKPIS.Sum(x => x.KpiPercent) / (decimal)employeeKPIS.Count());
            }

            #endregion

            return new
            {
                Status = 200,
                Name = langKey == "ar" ? employee.Name1 ?? "" : employee.Name1 ?? "",
                ContractStartDate = employee.ContractSrtDate.HasValue ? employee.ContractSrtDate.Value.ToString("dd/MM/yyyy") : "",
                Phone = employee.Phone1 ?? "",
                Address = langKey == "ar" ? employee.Address1 ?? "" : employee.Address1 ?? "",
                Job = (employee.Job != null) ? (langKey == "ar" ? employee.Job.Jname1 ?? "" : employee.Job.Jname1 ?? "") : "",
                AnnualVacsBalance = employee.AnnualVacsBalance ?? 0,
                ReservedVacsBalance = employee.ReservedVacsBalance ?? 0,
                KPIS = KPISValue + "  % ",
                NumberOfOpenedLoan = 0
            };
        }

        public object CheckQR(Point location, int EmpId, string langKey, bool In, bool shift = true)
        {
            int? store = null;
            int? shiftId = null;
            var dateNow = DateTime.UtcNow.AddHours(HourServer.hours);
            var now = dateNow.Date;
            string theLocation = "";

            Location StoreLocation = new Location();
            if (shift)
            {
                Dictionary<string, string> Dic = new Dictionary<string, string>();
                var keys = location.Qr.Split('&').SelectMany(x => x.Split("=")).ToArray();


                for (int i = 2; i <= keys.Length; i += 2)
                {
                    Dic.Add(keys[i - 2], keys[i - 1]);
                }

                int.TryParse(Dic["store"], out int _store);
                int.TryParse("0"/*Dic["shiftId"]*/, out int _shiftId);

                store = _store;
                shiftId = _shiftId;
                int dayOfWeek = _AppDate.GetDateIndex();

                var employeeShifts = _repHrEmpShift.GetAll().Where(x => x.EmpId == EmpId).Include(x => x.HrShifts).ToList().Select(x => new
                {
                    StartTime = dayOfWeek == 0 ? (x.HrShifts.FirstShfDay1tFrom.HasValue ? (

                       dateNow.TimeOfDay - x.HrShifts.FirstShfDay1tFrom.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 1 ? (x.HrShifts.FirstShftDay2From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay2From.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 2 ? (x.HrShifts.FirstShftDay3From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay3From.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 3 ? (x.HrShifts.FirstShftDay4From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay4From.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 4 ? (x.HrShifts.FirstShftDay5From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay5From.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 5 ? (x.HrShifts.FirstShftDay6From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay6From.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 6 ? (x.HrShifts.FirstShftDay7From.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay7From.Value.TimeOfDay).Hours : 0) : 0,

                    EndTime = dayOfWeek == 0 ?
                        (x.HrShifts.FirstShftDay1To.HasValue ?
                        (dateNow.TimeOfDay - x.HrShifts.FirstShftDay1To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 1 ? (x.HrShifts.FirstShftDay2To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay2To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 2 ? (x.HrShifts.FirstShftDay3To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay3To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 3 ? (x.HrShifts.FirstShftDay4To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay4To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 4 ? (x.HrShifts.FirstShftDay5To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay5To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 5 ? (x.HrShifts.FirstShftDay6To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay6To.Value.TimeOfDay).Hours : 0) :
                       dayOfWeek == 6 ? (x.HrShifts.FirstShftDay7To.HasValue ? (dateNow.TimeOfDay - x.HrShifts.FirstShftDay7To.Value.TimeOfDay).Hours : 0) : 0,
                    ShiftId = x.ShiftId
                }).ToList();

                if (!employeeShifts.Any())
                    return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? "هذا الموظف غير مرتبط  بهذة الفترة" : "This employee is not related to this period ")
                    };

                if (In)
                {
                    shiftId = employeeShifts.OrderBy(x => x.StartTime).FirstOrDefault().ShiftId;
                }
                else
                {
                    shiftId = employeeShifts.OrderBy(x => x.EndTime).FirstOrDefault().ShiftId;
                }

                var checkIfAttend = _repMobile_Attendance.GetAll().Include(x => x.HrEmployees).ThenInclude(x => x.HrEmpShifts).ThenInclude(x => x.HrShifts)
                    .Where(x => x.Emp_Id == EmpId && x.StoreId == store && x.ShftId == shiftId && x.TrDate.Value.Date == now && x.In == In && (!x.Status.HasValue || x.Status.Value));

                if (checkIfAttend.Any())
                {
                    return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? $" تم تأكيد  {(In ? "الحضور" : "الانصراف")}  مسبقأ  " : $"{(In ? "Attendance" : "Leave")} has already been confirmed")
                    };
                }

                var EmpStore = _repHrEmpStore.GetAll().Where(x => x.EmpId == EmpId && x.StoreId == store).Include(x => x.Stores);

                if (!EmpStore.Any())
                {
                    return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? "هذا الموظف غير مرتبط بهذا الفرع" : "This employee is not related to this Store")
                    };

                }

                StoreLocation = EmpStore.Select(x => new Location
                {
                    Lat = x.Stores.Lat,
                    Lng = x.Stores.Lng
                }).FirstOrDefault();
            }
            else
            {
                var checkIfAttend = _repMobile_Attendance.GetAll()
                  .Where(x => x.Emp_Id == EmpId && x.TrDate.Value.Date == DateTime.Now && x.In == In && (!x.Status.HasValue || x.Status.Value));

                if (checkIfAttend.Any())
                {
                    return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? $" مسبقأ {(In ? "الحضور" : "الانصراف")}تم تأكيد  " : $"{(In ? "Attendance" : "Leave")} has already been confirmed")
                    };
                }

                var EmpStore = _repHrEmpLocations.GetAll().Where(x => x.EmpId == EmpId).Include(x => x.HrLocation);

                if (!EmpStore.Any())
                {
                    return new
                    {
                        Status = 500,
                        message = (langKey == "ar" ? "هذا الموظف غير مرتبط  بموقع" : "This employee is not related to Location")
                    };
                }

                var _EmpStore = _repHrEmpStore.Find(x => x.EmpId == EmpId).FirstOrDefault();
                var employeeShift = _repHrEmpShift.Find(x => x.EmpId == EmpId).FirstOrDefault();
                store = _EmpStore?.StoreId;
                shiftId = employeeShift?.ShiftId;
                StoreLocation = EmpStore.Select(x => new Location { Lat = x.HrLocation.Lat, Lng = x.HrLocation.Lng }).FirstOrDefault();
            }

            //double distance = CalculateDistanceBetweenTwoPoints(location, new Point { lat = double.Parse(StoreLocation.Lat), lng = double.Parse(StoreLocation.Lng) });
            //var ch = distance >= 0 && distance <= 500;

            // في  السطر هنا انا جبت جميع الفروع الخاصه بالموظف

            var EmpBranches = _repHrEmpLocations.GetAll().Where(x => x.EmpId == EmpId).Include(x => x.HrLocation);

            // و هنا جبت الفرع بتاعه الي من القيم الي بعتها في تسجيل الدخول 
            //var EmployeeLocation = EmpBranches.FirstOrDefault(x =>
            //    double.Parse(x.HrLocation.Lat) == location.lat &&
            //    double.Parse(x.HrLocation.Lng) == location.lng);

            //double distance;

            //if (EmployeeLocation != null)
            //{
            //     distance = this.distance(location.lat, location.lng, double.Parse(EmployeeLocation.HrLocation.Lat), double.Parse(EmployeeLocation.HrLocation.Lng), 'M');

            //}
            //else
            //{
            //     distance = this.distance(location.lat, location.lng, double.Parse(StoreLocation.Lat), double.Parse(StoreLocation.Lng), 'M');

            //}

            //double distance = this.distance(location.lat, location.lng, double.Parse(StoreLocation.Lat), double.Parse(StoreLocation.Lng), 'M');

            //var ch = distance <= 500;

            var ch = false;
            double distance = 0;

            foreach (var empBranch in EmpBranches)
            {
                 distance = this.distance(location.lat, location.lng, double.Parse(empBranch.HrLocation.Lat), double.Parse(empBranch.HrLocation.Lng), 'M');

                if (distance <= 500)
                {
                    // إذا كانت المسافة أقل من أو تساوي 500 متر
                    ch = true;


                    var EmpLocationLogin = _hrLocation.GetAll().Where(s => s.Lat == empBranch.HrLocation.Lat && s.Lng == empBranch.HrLocation.Lng).FirstOrDefault();

                    if (EmpLocationLogin != null)
                    {
                        theLocation = EmpLocationLogin.Name1;
                    }
                    break; // يمكنك إزالة هذا إذا أردت متابعة التكرار حتى النهاية
                }
            }


            if (ch)
                _repMobile_Attendance.Insert(new Mobile_Attendance
                {
                    Emp_Id = EmpId,
                    In = In,
                    Out = !In,
                    Status = ch,
                    StoreId = store,
                    ShftId = shiftId,
                    TrDate = DateTime.UtcNow.AddHours(HourServer.hours),
                    Distance = distance,
                    Qr = location.Qr,
                    LocationName = theLocation
                });

            //return new
            //{
            //    Status = 200,
            //    message = ch ?
            //    (langKey == "ar" ? (In ? "تم  تأكيد الحضور بنجاح" : "تم تأكيد الانصراف بنجاح")
            //    : (In ? "Attendance has been confirmed successfully" : "Leave has been confirmed successfully"))
            //    : (langKey == "ar" ? $"  تبعد عن الفرع مسافة كبيرة ولا يمكن تأكيد  {(In ? "الحضور" : "الانصراف")}"
            //    : $"It is a long distance from the branch and {(In ? "attendance" : "leave")}  cannot be confirmed")
            //};

            string message = string.Empty;
            if (ch)
            {
                if (langKey == "ar")
                    message = In ? "تم  تأكيد الحضور بنجاح" : "تم تأكيد الانصراف بنجاح";
                else
                    message = In ? "Attendance has been confirmed successfully" : "Leave has been confirmed successfully";
            }
            else
            {
                string errorMessage = "longitude = " + location.lat + " and latitude = " + location.lng + " and distance is "+ distance;
                if (langKey == "ar")
                    message = $"  تبعد عن الفرع مسافة كبيرة ولا يمكن تأكيد  {(In ? "الحضور" : "الانصراف")} ";
                else
                    message = $"It is a long distance from the branch and {(In ? "attendance" : "leave")}  cannot be confirmed";

                message += errorMessage;
            }
            return new { Status = 200, message = message };
        }

        public object CheckQR(string _location, int EmpId, string langKey)
        {
            var loc = _location.Split(",");
            Point location = new Point { lat = double.Parse(loc[0]), lng = double.Parse(loc[1]) };

            return CheckQR(location, EmpId, langKey, true);
        }

        public object GetQrCode(int storeId, int width, int height)
        {

            return new
            {
                qrCode = ("store=" + storeId + "&shiftId=" + 0 + "&DateTime=" + DateTime.UtcNow.AddHours(HourServer.hours).ToString("MM-dd-yyyy HH:mm:ss")).ToImageQrcode(width, height),
                date = DateTime.UtcNow.AddHours(HourServer.hours).ToString("MM-dd-yyyy HH:mm:ss")
            };
        }

        public double getMiles(double meters)
        {
            return meters * 0.000621371192;
        }

        public double getMeters(double miles)
        {
            return miles * 1609.344;
        }

        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
                return 0;
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                else if (unit == 'M')
                {
                    /// ////// Convert miles to meters
                    dist = getMeters(dist);
                }
                return (dist);
            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }


        /// <summary>
        /// //// old code to calc distance
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public double CalculateDistanceBetweenTwoPoints(Point p1, Point p2)
        //{
        //    var R = 6378137;
        //    var dLat = rad(p2.lat - p1.lat);
        //    var dLong = rad(p2.lng - p1.lng);
        //    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(rad(p1.lat)) * Math.Cos(rad(p2.lat)) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
        //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); var d = R * c;
        //    return d;
        //}

        private double rad(double x)
        {
            return x * Math.PI / 180;
        }

        private int GetEmployeeId(int userId)
        {
            var user = _repUser.GetById(userId);
            if (user == null)
                return 0;

            if (user.EmpId == null)
                return 0;

            int EmpId = user.EmpId.Value;

            return user.EmpId.Value;
        }
    }

    /// <summary>
    /// This Class Manage a string to convert it to a barcode or qrcode
    /// </summary>
    internal class ManageQrBarcode
    {
        #region Props
        /// <summary>
        /// Content To Convert It To a barcode image, qrcode image  etc... 
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Width Of The Barcode , QrCode , etc ....  Image
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Height Of The Barcode , QrCode , etc ....  Image
        /// </summary>
        public int Height { get; private set; }
        #endregion

        #region Ctors
        public ManageQrBarcode(string Content, int Width, int Height)
        {
            this.Content = Content;
            this.Width = Width;
            this.Height = Height;
        }
        #endregion

        #region Methods
        /// <summary>
        /// It Converts a string to barcode image , qrcode image ,etc...
        /// </summary>
        /// <param name="barcodeFormat">Format is a barcode(Code_128) or qrcode or whatever you want</param>
        /// <returns></returns>
        public byte[] Stream(BarcodeFormat barcodeFormat)
        {
            //
            BarcodeWriterPixelData CodeWriter = new BarcodeWriterPixelData()
            {
                // Format is barcode or qrcode
                Format = barcodeFormat,
                Options = new EncodingOptions() { Width = Width, Height = Height, Margin = 0 }
            };

            PixelData Pixel_Data = CodeWriter.Write(Content);

            using Bitmap Bit = new Bitmap(Pixel_Data.Width, Pixel_Data.Height, PixelFormat.Format32bppArgb);
            using MemoryStream Memory = new MemoryStream();
            BitmapData bitMapData = Bit.LockBits(new System.Drawing.Rectangle(0, 0, Pixel_Data.Width, Pixel_Data.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try { Marshal.Copy(Pixel_Data.Pixels, 0, bitMapData.Scan0, Pixel_Data.Pixels.Length); }
            finally { Bit.UnlockBits(bitMapData); }

            Bit.Save(Memory, ImageFormat.Png);

            return Memory.ToArray();
        }

        /// <summary>
        /// Get a base64 image src from qrcode , barcode , etc
        /// </summary>
        /// <param name="barcodeFormat">Format is a barcode(Code_128) or qrcode or whatever you want</param>
        /// <returns></returns>
        public string Base64ImageSrc(BarcodeFormat barcodeFormat) => ExtentionMethod.ImageFromBase64(Convert.ToBase64String(Stream(barcodeFormat)));
        #endregion
    }

    public static class ExtentionMethod
    {
        public static string ImageFromBase64(string base64) => string.Format("data:image/png;base64,{0}", base64);

        public static string ToImageQrcode(this string content, int width, int height)
        {
            return new ManageQrBarcode(content, width, height).Base64ImageSrc(BarcodeFormat.QR_CODE);
        }

        public static string ToImageBarcode(this string content, int width, int height)
        {
            return new ManageQrBarcode(content, width, height).Base64ImageSrc(BarcodeFormat.CODE_128);
        }
    }
}
