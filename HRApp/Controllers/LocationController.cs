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
    public class LocationController : Controller
    {
        LocationBLL _LocationBLL;
        public LocationController(LocationBLL LocationBLL)
        {
            _LocationBLL = LocationBLL;
        }
        public IActionResult Index()
        {
            ViewData["Count"] = _LocationBLL.GetCount();
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

        public JsonResult Add(LocationDTO mdl)
        {
            if(mdl.LocationId==0)
            return Json(_LocationBLL.Add(mdl));
            else
                return Json(_LocationBLL.Edit(mdl));
        }
        public JsonResult Delete(int id)
        {
            return Json(_LocationBLL.Delete(id));
        }

        public JsonResult DisplayDataForEdit(int id)
      => Json(_LocationBLL.DisplayDataForEdit(id));

        public JsonResult GetItemByIndex(int index)
      => Json(_LocationBLL.GetItemByIndex(index));

        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_LocationBLL.LoadData(mdl));
        }
    }
}
