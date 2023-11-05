using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using X.PagedList;

namespace HRApp.Controllers
{
    public class VacationRequestController : Controller
    {
        private readonly SmartERPStandardContext _db;

        public VacationRequestController(SmartERPStandardContext db)
        {
            _db = db;

        }

        public IActionResult Index(int pageIndex = 1, int pageSize = 20)
        {
            var item = (from emp in _db.HrEmployees
                       join vaca in _db.HrVacationRequest on emp.EmpId equals vaca.EmpId
                       select new HR_EmployeeAndVacationRequestDto
                       {
                           EmpId = emp.EmpId,
                           VacRequestId = vaca.VacRequestId,
                           name = emp.Name1,
                           VacaEmpId = (int)vaca.EmpId,
                           fromDate = (System.DateTime)vaca.FromDate,
                           ToDate = (System.DateTime)vaca.ToDate,
                           DayCount = (int)vaca.DayCount,
                           Closed = (bool)vaca.Closed,
                           CloseDate = (System.DateTime)vaca.CloseDate,
                           Remarks1 = vaca.Remarks1,
                           Remarks3 = vaca.Remarks3,
                       }).ToPagedList(pageIndex, pageSize);

            return View(item);
        }

        public IActionResult Edit(int? VacRequestId)
        {
            if (VacRequestId == null)
                return BadRequest("Not Found");

            var Vacation = _db.HrVacationRequest.Find(VacRequestId);

            if (Vacation == null)
                return NotFound("Not Found");

            var VacationItem = new HR_EmployeeAndVacationRequestDto()
            {
                VacRequestId = Vacation.VacRequestId,
                DayCount = (int)Vacation.DayCount,
                fromDate = (DateTime)Vacation.FromDate,
                ToDate = (DateTime)Vacation.ToDate,
                Remarks3 = Vacation.Remarks3,
                Closed = Vacation.Closed,


            };

            return View("VacationForm", VacationItem);

        }


        [HttpPost]
        public IActionResult Edit(HR_EmployeeAndVacationRequestDto Vac)
        {
            var vacation = _db.HrVacationRequest.Find(Vac.VacRequestId);
            if (vacation == null) return NotFound();

            vacation.FromDate = Vac.fromDate;
            vacation.ToDate = Vac.ToDate;
            vacation.CloseDate = DateTime.Now;
            vacation.DayCount = Vac.DayCount;
            vacation.Remarks3 = Vac.Remarks3;
            vacation.Closed = Vac.Closed;


            _db.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult filter(bool? dropSelect , DateTime? FromDate, DateTime? ToDate , int pageIndex = 1, int pageSize = 20)
        {
           

            var query =from emp in _db.HrEmployees
                        join vaca in _db.HrVacationRequest on emp.EmpId equals vaca.EmpId
                        select new HR_EmployeeAndVacationRequestDto
                        {
                            EmpId = emp.EmpId,
                            VacRequestId = vaca.VacRequestId,
                            name = emp.Name1,
                            VacaEmpId = (int)vaca.EmpId,
                            fromDate = (System.DateTime)vaca.FromDate,
                            ToDate = (System.DateTime)vaca.ToDate,
                            DayCount = (int)vaca.DayCount,
                            Closed = (bool)vaca.Closed,
                            CloseDate = (System.DateTime)vaca.CloseDate,
                            Remarks1 = vaca.Remarks1,
                            Remarks3 = vaca.Remarks3,
                        };

           if (!dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == null);

            if (dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == dropSelect.Value);

            if (FromDate.HasValue)
                query = query.Where(vaca => vaca.fromDate >= FromDate);

            if (ToDate.HasValue)
                query = query.Where(vaca => vaca.ToDate <= ToDate);
            


            return View("IndexFilter", query.ToPagedList(pageIndex, pageSize));


        }

    }

}
