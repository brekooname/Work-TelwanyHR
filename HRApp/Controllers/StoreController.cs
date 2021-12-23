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
    public class StoreController : Controller
    {
        StoreBLL _StoreBLL;
        public StoreController(StoreBLL storeBLL)
        {
            _StoreBLL = storeBLL;
        }
        public IActionResult Index()
        {
            ViewData["Count"] = _StoreBLL.GetCount();
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

        public JsonResult Add(StoreDTO mdl)
        {
            if(mdl.StoreId==0)
            return Json(_StoreBLL.Add(mdl));
            else
                return Json(_StoreBLL.Edit(mdl));
        }
        public JsonResult Delete(int id)
        {
            return Json(_StoreBLL.Delete(id));
        }

        public JsonResult DisplayDataForEdit(int id)
      => Json(_StoreBLL.DisplayDataForEdit(id));

        public JsonResult GetItemByIndex(int index)
      => Json(_StoreBLL.GetItemByIndex(index));



        public JsonResult LoadData(DataTableDTO mdl)
        {
            return Json(_StoreBLL.LoadData(mdl));
        }
    }
}
