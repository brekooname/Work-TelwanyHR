using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using HR;
using HR.BLL;
using HR.BLL.DTO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Areas.Api
{
    [ApiController]
    [Route("api/[controller]/[Action]/{id?}")]
    public class VacationController : Controller
    {
        private readonly VacationBll _vacationBll;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VacationController(VacationBll vacationBll, IWebHostEnvironment webHostEnvironment)
        {
            _vacationBll = vacationBll;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public object Request([FromForm] VacationRequestDTO mdl,[FromQuery] string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            string fileUrl = "";
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var file = files[0];
                    fileUrl = Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(file.FileName);
                    string path = _webHostEnvironment.WebRootPath + "/Upload/"
                        + fileUrl;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Dispose();
                    }
                }
            }
            catch {; }
            mdl.ImageUrl = fileUrl;

            mdl.EmployeeId = int.Parse(userId);
            var result = _vacationBll.Add(mdl,langKey);

            return result;

        }

        [HttpPost]
        public object UpdateRequest([FromForm] EditVacationRequestDTO mdl, [FromQuery] string langKey)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            string fileUrl = "";
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    var file = files[0];
                    fileUrl = Path.GetRandomFileName().Replace(".", "") + Path.GetExtension(file.FileName);
                    string path = _webHostEnvironment.WebRootPath + "/Upload/"
                        + fileUrl;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Dispose();
                    }
                }
            }
            catch 
            {
                ;
            }
            mdl.ImageUrl = fileUrl;

            mdl.EmployeeId = int.Parse(userId);
            var result = _vacationBll.Update(mdl, langKey);

            return result;

        }

        public object GetVacationRequestById(int vacationId)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _vacationBll.GetVacationRequestById(int.Parse(userId), vacationId);

            //string path = _webHostEnvironment.WebRootPath + "/Upload/" + () result;

            return result;

        }


        public object EmployeeVacations(int pageIndex = 1, bool total = false, string langKey = "ar")
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _vacationBll.EmployeeVacation(int.Parse(userId),pageIndex,total,langKey);

            return result;
        }

    }
}
