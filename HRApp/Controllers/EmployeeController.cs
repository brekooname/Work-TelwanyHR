using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using HR.BLL;
using HR.BLL.DTO;
using HR.Tables.Tables;
using HR.Web.Helper;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public EmployeeController(StoreBLL storeBLL, ShiftBLL shiftBLL, JobBLL jobBLL, LocationBLL 
            locationBLL, EmployeeBll employeeBll, AccountBll accountBll,
            ReportsBLL reportsBLL, IWebHostEnvironment webHostEnvironment)
        {
            _StoreBLL = storeBLL;
            _ShiftBLL = shiftBLL;
            _JobBLL = jobBLL;
            _LocationBLL = locationBLL;
            _EmployeeBll = employeeBll;
            _AccountBll = accountBll;
            _reportsBLL = reportsBLL;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["Count"] = _EmployeeBll.GetCount();

            ViewData["shifts"] = _ShiftBLL.Shifts();
            ViewData["jobs"] = _JobBLL.Jobs();
            ViewData["stores"] = _StoreBLL.Stores();
            ViewData["locations"] = _LocationBLL.locations();

            return View();
        }

        public IActionResult Report()
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

        public JsonResult LoadAttendanceData(DataTableDTO mdl)
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
