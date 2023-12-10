using HR.BLL.DTO;
using HR.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;
using System;
using System.Threading.Tasks;

namespace HRApp.Controllers
{
    public class PermissionRequestController : Controller
    {
        private readonly SmartERPStandardContext _db;

        public PermissionRequestController(SmartERPStandardContext db)
        {
            _db = db;

        }
     
        public IActionResult Index(int pageIndex = 1, int pageSize = 20)
        {
            try
            {
                var item = _db.SearchLeavPermissionRequest.Where(s => s.DeletedBy == null).ToPagedList(pageIndex, pageSize);
                return View(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public IActionResult Edit(int? LeavPermReqId)
        {
            if (LeavPermReqId == null)
                return BadRequest("Not Found");

            var permission = _db.HrLeavPermissionRequest.Find(LeavPermReqId);

            if (permission == null)
                return NotFound("Not Found");

            var permissionItem = new HR_LeavPermissionRequestDto()
            {
               
                LeavPermReqId = permission.LeavPermReqId,
                Remarks3 = permission.Remarks3,
                Closed = permission.Closed
                


            };

            return View("PermissionForm", permissionItem);

        }


        [HttpPost]
        public IActionResult Edit(HR_LeavPermissionRequestDto perm)
        {
            var permission = _db.HrLeavPermissionRequest.Find(perm.LeavPermReqId);

            if (permission == null) return NotFound();

            permission.Closed = perm.Closed;
            permission.CloseDate = DateTime.Now;
            permission.Remarks3 = perm.Remarks3;
            permission.UpdateAt = DateTime.Now;

            _db.SaveChanges();

            return RedirectToAction("index");

        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null) return BadRequest();

            var permission = await _db.HrLeavPermissionRequest.FindAsync(id);

            if (permission == null) return NotFound();

            permission.Closed= true;
            permission.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Refuse(int? id)
        {
            if (id == null) return BadRequest();

            var permission = await _db.HrLeavPermissionRequest.FindAsync(id);

            if (permission == null) return NotFound();

            permission.Closed = false;
            permission.CloseDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("index");
        }


        public async Task<IActionResult> delete(int? id)
        {
            if (id == null) return BadRequest();

            var permission = await _db.HrLeavPermissionRequest.FindAsync(id);

            if (permission == null) return NotFound();

            permission.DeletedBy = "admin";
            permission.DeletedAt = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult filter(string EmpName, bool? dropSelect, DateTime? FromDate, DateTime? ToDate, int pageIndex = 1, int pageSize = 20)
        {
            //var query = from emp in _db.HrEmployees
            //            join perm in _db.HrLeavPermissionRequest on emp.EmpId equals perm.EmpId
            //            where perm.DeletedBy == null
            //            select new HR_LeavPermissionRequestDto
            //            {
            //                EmpId = emp.EmpId,
            //                Name1 = emp.Name1,
            //                LeavPermReqId = perm.LeavPermReqId,
            //                fromDate = (DateTime)perm.FromDate,
            //                Closed = (bool)perm.Closed,
            //                CloseDate = (DateTime)perm.CloseDate,
            //                FromTime = (DateTime)perm.FromTime,
            //                ToTime = (DateTime)perm.ToTime,
            //                HoursCount = (int)perm.HoursCount,
            //                Remarks1 = perm.Remarks1,
            //                Remarks3 = perm.Remarks3,
            //            };

            var query = _db.SearchLeavPermissionRequest.Where(s => s.DeletedBy == null);

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
                query = query.Where(vaca => vaca.FromDate <= ToDate);



            return View("IndexFilter", query.ToPagedList(pageIndex, pageSize));


        }
    }
}
