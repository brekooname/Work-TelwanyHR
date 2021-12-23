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
    public class JobController : Controller
    {
        JobBLL _JobBLL;
        public JobController(JobBLL JobBLL)
        {
            _JobBLL = JobBLL;
        }
        public IActionResult Index()
        {
            ViewData["Count"] = _JobBLL.GetCount();
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

        public JsonResult Add(JobDTO mdl)
        {
            if(mdl.JobId==0)
            return Json(_JobBLL.Add(mdl));
            else
                return Json(_JobBLL.Edit(mdl));
        }
        public JsonResult Delete(int id)
        {
            return Json(_JobBLL.Delete(id));
        }

        public JsonResult DisplayDataForEdit(int id)
      => Json(_JobBLL.DisplayDataForEdit(id));

        public JsonResult GetItemByIndex(int index)
   => Json(_JobBLL.GetItemByIndex(index));

        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_JobBLL.LoadData(mdl));
        }
    }
}
