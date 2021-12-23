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
    public class LoanController : Controller
    {
        private readonly LoanBll _LoanBll;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoanController(LoanBll LoanBll, IWebHostEnvironment webHostEnvironment)
        {
            _LoanBll = LoanBll;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public object Request([FromForm] LoanRequestDTO mdl,[FromQuery] string langKey)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var files = HttpContext.Request.Form.Files;
            string fileUrl = "";
            try
            {
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
            var result = _LoanBll.Add(mdl, langKey);

            return result;

        }

        [HttpPost]
        public object UpdateRequest([FromForm] EditLoanRequestDTO mdl, [FromQuery] string langKey)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var files = HttpContext.Request.Form.Files;
            string fileUrl = "";
            try
            {
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
            var result = _LoanBll.Update(mdl, langKey);

            return result;

        }

        public object GetLoanRequestById(int loanId)
        {
            var userId = HttpContext.User?.Identity?.Name;
            if (userId.IsEmpty()) return Unauthorized();

            var result = _LoanBll.GetLoanRequestById(int.Parse(userId), loanId);

            return result;

        }
    }
}
