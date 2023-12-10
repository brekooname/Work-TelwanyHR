using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using HR.BLL;
using HR.BLL.DTO;
using HR.DAL;
using HR.Static;
using HR.Tables.Tables;
using HR.Web.Helper;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using X.PagedList;

namespace HRApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        StoreBLL _StoreBLL;
        JobBLL _JobBLL;
        ShiftBLL _ShiftBLL;
        LocationBLL _LocationBLL;
        EmployeeBll _EmployeeBll;
        AccountBll _AccountBll;
        ReportsBLL _reportsBLL;
        IWebHostEnvironment _webHostEnvironment;
        private readonly SmartERPStandardContext _db;
        private readonly IToastNotification _toaster;

        public EmployeeController(StoreBLL storeBLL, ShiftBLL shiftBLL, JobBLL jobBLL, LocationBLL 
            locationBLL, EmployeeBll employeeBll, AccountBll accountBll,
            ReportsBLL reportsBLL, IWebHostEnvironment webHostEnvironment,
            SmartERPStandardContext db , IToastNotification toaster)
        {
            _StoreBLL = storeBLL;
            _ShiftBLL = shiftBLL;
            _JobBLL = jobBLL;
            _LocationBLL = locationBLL;
            _EmployeeBll = employeeBll;
            _AccountBll = accountBll;
            _reportsBLL = reportsBLL;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _toaster = toaster;
        }
        
        public IActionResult Index()
        {
            ViewData["Count"] = _EmployeeBll.GetCount();
            ViewData["shifts"] = _ShiftBLL.Shifts();
            ViewData["Period"] = _ShiftBLL.Period();
            ViewData["jobs"] = _JobBLL.Jobs();
            ViewData["stores"] = _StoreBLL.Stores();
            ViewData["locations"] = _LocationBLL.locations();

            return View();
        }
       
        public IActionResult Report()
        {
            return View();
        }
        

        public IActionResult AttendanceReport()
        {
            return View();
        }
        
        public IActionResult DelayReport()
        {
            return View();
        }
        
        public IActionResult DelayReportDetails()
        {
            return View();
        }
        
        public IActionResult Users()
        {
            ViewData["Count"] = _EmployeeBll.GetUsersCount();

            return View();
        }
        public async Task<IActionResult> createAddendance()
        {
            var model = new CreateAttendanceDto()
            {
                Employees = await _db.HrEmployees.Where(e => e.DeletedBy == null && e.DeletedAt == null).ToListAsync(),
                stores = await _db.MsStores.Where(e => e.DeletedBy == null && e.DeletedAt == null).ToListAsync(),
                shifts = await _db.HrShifts.Where(s=>s.DeletedAt == null && s.DeletedBy == null).ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> createAddendance(CreateAttendanceDto dto)
        {

            if (!ModelState.IsValid)
            {
                dto.Employees = await _db.HrEmployees.Where(e => e.DeletedBy == null && e.DeletedAt == null).ToListAsync();
                dto.stores = await _db.MsStores.Where(e => e.DeletedBy == null && e.DeletedAt == null).ToListAsync();
                dto.shifts = await _db.HrShifts.Where(s => s.DeletedAt == null && s.DeletedBy == null).ToListAsync();
                return View(dto);

            }

            var AddAttendance = new Mobile_Attendance
            {
                Emp_Id = dto.Emp_Id,
                TrDate = dto.TrDate,
                In = dto.In,
                StoreId = dto.StoreId,
                ShftId = dto.ShftId
            };

            _db.Mobile_Attendance.Add(AddAttendance);
            _db.SaveChanges();
            _toaster.AddSuccessToastMessage("تم أضافة الطلب بنجاح");
            return RedirectToAction("Report");
        }

        [HttpGet]
        public JsonResult EditAttendance(int? id)
        {
            var GetAttendanceRecord = _db.Mobile_Attendance.Find(id);
            return Json(GetAttendanceRecord);
        }

        [HttpPost]
        public JsonResult UpdateAttendance(ModifyingAttendanceDto dto)
        {
            if (ModelState.IsValid)
            {
                 Mobile_Attendance GetRecord = _db.Mobile_Attendance.Find(dto.AttendanceId);
                GetRecord.TrDate = dto.TrDate;
                _db.SaveChanges();

                return Json("تم التحديث بنجاح");
            }
            return Json("model validation failed.");

        }

        [HttpGet]     
  
        public IActionResult ModifyingAttendance(int? id)
        {

            Mobile_Attendance GetAttendance = _db.Mobile_Attendance.FirstOrDefault(a => a.AttendanceId == id);
            if (GetAttendance == null)
                return NotFound();
            HrEmployees getEmploye = _db.HrEmployees.FirstOrDefault(e => e.EmpId == GetAttendance.Emp_Id);
            ModifyingAttendanceDto GetAttendanceDto = new ModifyingAttendanceDto()
            {
                AttendanceId = GetAttendance.AttendanceId,
                TrDate = GetAttendance.TrDate,
                EmployeeName = getEmploye.Name1 ?? ""

            };

            return View("FormModifyingAttendance", GetAttendanceDto);

        }
        [HttpPost]
        public IActionResult ModifyingAttendance(ModifyingAttendanceDto dto)
        {

            Mobile_Attendance GetAttendance = _db.Mobile_Attendance.FirstOrDefault(a => a.AttendanceId == dto.AttendanceId);

            if (GetAttendance == null)
                return NotFound();

            GetAttendance.TrDate = dto.TrDate;

            _db.SaveChanges();
            return RedirectToAction("report");
        }
        public JsonResult GetEmployees(int ?id)
            => Json(_EmployeeBll.getEmployeesNotHaveUser(id));
        
        public JsonResult Add(HrEmployees mdl)
        {
            var file = HttpContext.Request.Form.Files;
            if (file!=null&&file.Count>0)
            {
                var f = file[0];
                string path = System.IO.Path.GetRandomFileName().Replace(".", "")+System.IO.Path.GetExtension(f.FileName);
              string FullPath=  _webHostEnvironment.WebRootPath + "/Upload/"+path;
                using (var fileStream = new FileStream(FullPath, FileMode.CreateNew))
                {
                    f.CopyTo(fileStream);
                    fileStream.Dispose();
                }
                mdl.ImageUrl = path;
            }

            if (mdl.EmpId == 0)
                return Json(_EmployeeBll.Add(mdl));
            else
                return Json(_EmployeeBll.Edit(mdl));
        }
        
        public JsonResult AddUser(GUsers mdl)
        {
            if (mdl.UserId == 0)
                return Json(_EmployeeBll.AddUser(mdl));
            else
                return Json(_EmployeeBll.EditUser(mdl));
        }
        
        public JsonResult Delete(int id)
        {
            return Json(_EmployeeBll.Delete(id));
        }
        
        public JsonResult DeleteUser(int id)
        {
            return Json(_EmployeeBll.DeleteUser(id));
        }
        
        public JsonResult DisplayUserDataForEdit(int id)
             => Json(_EmployeeBll.DisplayUserDataForEdit(id));
        
        public JsonResult DisplayDataForEdit(int id)
      => Json(_EmployeeBll.DisplayDataForEdit(id));
        
        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_EmployeeBll.LoadData(mdl));
        }
        
        public JsonResult LoadUsersData(DataTableDTO mdl)
        {
            return Json(_EmployeeBll.LoadUsersData(mdl));
        }
        
        public JsonResult LoadAttendanceReportData2(DataTableDTO mdl)
        {
            return Json(_reportsBLL.LoadDelayReport(mdl, true));
        }
        
        public JsonResult LoadAttendanceReportData(DataTableDTO mdl)
        {
            return Json(_AccountBll.LoadAttendanceData(mdl));
        }

        public JsonResult LoadDelayReportData(DataTableDTO mdl)
        {
            return Json(_reportsBLL.LoadDelayReport(mdl));
        }

        public JsonResult LoadDelayDetailsReportData(DataTableDTO mdl)
        {
            return Json(_reportsBLL.LoadDelayDetailsReport(mdl));
        }
        
        public JsonResult GetItemByIndex(int index)
=> Json(_EmployeeBll.GetItemByIndex(index));  
        
        public JsonResult GetUserItemByIndex(int index)
=> Json(_EmployeeBll.GetUserItemByIndex(index));
    }
}
