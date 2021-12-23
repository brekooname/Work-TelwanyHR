using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HR.BLL;
using HR.BLL.DTO;
using HR.Web.Helper;

using Microsoft.AspNetCore.Mvc;

namespace HRApp.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        ShiftBLL _ShiftBLL;
        public ShiftController(ShiftBLL ShiftBLL)
        {
            _ShiftBLL = ShiftBLL;
        }
        public IActionResult Index()
        {
            ViewData["Count"] = _ShiftBLL.GetCount();

            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        public JsonResult Add(ShiftDTO mdl)
        {
            if(mdl.ShiftId==0)
            return Json(_ShiftBLL.Add(mdl));
            else
                return Json(_ShiftBLL.Edit(mdl));
        }
        public JsonResult Delete(int id)
        {
            return Json(_ShiftBLL.Delete(id));
        }

        public JsonResult DisplayDataForEdit(int id)
      => Json(_ShiftBLL.DisplayDataForEdit(id));

        public JsonResult GetItemByIndex(int index)
         => Json(_ShiftBLL.GetItemByIndex(index));

        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_ShiftBLL.LoadData(mdl));
        }
    }
}
