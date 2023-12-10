using HR.BLL.DTO;
using HR.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using X.PagedList;

namespace HRApp.Controllers
{
    public class EmployeeLoanRequestController : Controller
    {

        private readonly SmartERPStandardContext _db;
        public EmployeeLoanRequestController(SmartERPStandardContext db)
        {
            _db = db;
        }
        public IActionResult Index(int pageIndex = 1, int pageSize = 20)
        {
            try
            {
                var item = _db.SearchEmpLoanRequest.Where(s=>s.DeletedBy == null).ToPagedList(pageIndex,pageSize);
                return View(item);
            } 
            catch(Exception ex)
            {
                return View();
            }
        }



        public IActionResult Edit(int? EmpLoanReqId)
        {
            if (EmpLoanReqId == null)
                return BadRequest("Not Found");

            var loanRequest = _db.HrEmpLoanRequest.Find(EmpLoanReqId);

            if (loanRequest == null)
                return NotFound("Not Found");

            var loan = new HR_LoanRequestDto()
            {

                EmpLoanReqId = loanRequest.EmpLoanReqId,
                Remarks3 = loanRequest.Remarks3,
                Closed = loanRequest.Closed



            };

            return View("LoanForm", loan);

        }


        [HttpPost]
        public IActionResult Edit(HR_LoanRequestDto loan)
        {
            var LoanRequest = _db.HrEmpLoanRequest.Find(loan.EmpLoanReqId);

            if (LoanRequest == null) return NotFound();

            LoanRequest.Closed = loan.Closed;
            LoanRequest.CloseDate = DateTime.Now;
            LoanRequest.Remarks3 = loan.Remarks3;
            LoanRequest.UpdateAt = DateTime.Now;

            _db.SaveChanges();

            return RedirectToAction("index");

        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null) return BadRequest();

            var loanRequest = await _db.HrEmpLoanRequest.FindAsync(id);

            if (loanRequest == null) return NotFound();

            loanRequest.Closed = true;
            loanRequest.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Refuse(int? id)
        {
            if (id == null) return BadRequest();

            var loanRequest = await _db.HrEmpLoanRequest.FindAsync(id);

            if (loanRequest == null) return NotFound();

            loanRequest.Closed = false;
            loanRequest.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("index");
        }


        public async Task<IActionResult> delete(int? id)
        {
            if (id == null) return BadRequest();

            var loanRequest = await _db.HrEmpLoanRequest.FindAsync(id);

            if (loanRequest == null) return NotFound();

            loanRequest.DeletedBy = "admin";
            loanRequest.DeletedAt = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult filter(string EmpName, bool? dropSelect, DateTime? FromDate, DateTime? ToDate, int pageIndex = 1, int pageSize = 20)
        {

            try
            {
                var query = _db.SearchEmpLoanRequest.Where(s => s.DeletedBy == null);
            

            if (!string.IsNullOrEmpty(EmpName))
            {
                query = query.Where(vaca => vaca.EmpName1.StartsWith(EmpName));
            }

            if (!dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == null);

            if (dropSelect.HasValue)
                query = query.Where(vaca => vaca.Closed == dropSelect.Value);

            if (FromDate.HasValue)
                query = query.Where(vaca => vaca.TrDate >= FromDate);

            if (ToDate.HasValue)
                query = query.Where(vaca => vaca.TrDate <= ToDate);



            return View("IndexFilter", query.ToPagedList(pageIndex, pageSize));
        }
              catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

        }
    }
}
