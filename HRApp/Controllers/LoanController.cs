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
    public class LoanController : Controller
    {
        LoanBll _service;
        public LoanController(LoanBll service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
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

        //public JsonResult Add(VacationRequestDTO mdl)
        //{
        //    if(mdl.JobId==0)
        //    return Json(_service.Add(mdl));
        //    else
        //        return Json(_service.Edit(mdl));
        //}

        //public JsonResult Delete(int id)
        //{
        //    return Json(_service.Delete(id));
        //}

        //public JsonResult DisplayDataForEdit(int id) => Json(_service.DisplayDataForEdit(id));

        //public JsonResult GetItemByIndex(int index) => Json(_service.GetItemByIndex(index));

        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_service.LoadData(mdl));
        }
    }
}
