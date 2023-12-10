using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            try
            {
                var item = _db.SearchVacationRequest.Where(s => s.DeletedBy == null).ToPagedList(pageIndex, pageSize);
                return View(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
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
            vacation.UpdateAt = DateTime.Now;


            _db.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult filter(string EmpName, bool? dropSelect , DateTime? FromDate, DateTime? ToDate , int pageIndex = 1, int pageSize = 20)
        {
           

            var query = _db.SearchVacationRequest.Where(v => v.DeletedBy == null);

            if (!string.IsNullOrEmpty(EmpName))
            {
                query = query.Where(vaca => vaca.EmpName1.StartsWith(EmpName));
            }


            if (!dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == null);

            if (dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == dropSelect.Value);

            if (FromDate.HasValue)
                query = query.Where(vaca => vaca.FromDate >= FromDate);

            if (ToDate.HasValue)
                query = query.Where(vaca => vaca.ToDate <= ToDate);
            


            return View("IndexFilter", query.ToPagedList(pageIndex, pageSize));


        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null) return BadRequest();

            var vacation = await _db.HrVacationRequest.FindAsync(id);

            if (vacation == null) return NotFound();

            vacation.Closed = true;
            vacation.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Refuse(int? id)
        {
            if (id == null) return BadRequest();

            var vacation = await _db.HrVacationRequest.FindAsync(id);

            if (vacation == null) return NotFound();

            vacation.Closed = false;
            vacation.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult delete(int? id)
        {
            if (id == null) return BadRequest();

            var vaca =  _db.HrVacationRequest.Find(id);

            if (vaca == null) return NotFound();

            vaca.DeletedBy = "admin";
            vaca.DeletedAt = DateTime.Now;

            _db.SaveChanges();

            return RedirectToAction("index");
        }
    }

}
