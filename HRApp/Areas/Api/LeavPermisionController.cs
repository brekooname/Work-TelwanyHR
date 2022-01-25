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
    public class LeavPermisionController : Controller
    {
        private readonly LeavPermisionBll _leavPermisionBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LeavPermisionController(LeavPermisionBll leavPermisionBll, IWebHostEnvironment webHostEnvironment)
        {
            _leavPermisionBll = leavPermisionBll;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public object Request([FromForm] LeavPermisionDTO mdl, [FromQuery] string langKey)
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
            var result = _leavPermisionBll.Add(mdl, langKey);

            return result;

        }

        [HttpPost]
        public object UpdateRequest([FromForm] EditLeavPermisionDTO mdl, [FromQuery] string langKey)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            string fileUrl = "";
            try
            {
                var files = HttpContext?.Request?.Form?.Files;
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
            catch (Exception ex)
            {
                ;
            }
            mdl.ImageUrl = fileUrl;

            mdl.EmployeeId = int.Parse(userId);
            var result = _leavPermisionBll.Update(mdl, langKey);

            return result;
        }

        public object GetLeavePremisionById(int leavePremisionId)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _leavPermisionBll.GetLeavePremisionById(int.Parse(userId), leavePremisionId);

            return result;

        }
    }
}
