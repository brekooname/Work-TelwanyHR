using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using HR;
using HR.BLL;
using HR.DAL;
using HR.Tables.Tables;
using HR.Web.Helper;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBll _AccountBll;
        private readonly SettingBLL _settingBLL;
        StoreBLL _StoreBLL;
        ShiftBLL _ShiftBLL;
        private IRepository<MsCompany> _repCompany;
        IWebHostEnvironment _webHostEnvironment;

        public HomeController(AccountBll AccountBll, StoreBLL storeBLL, ShiftBLL shiftBLL, IRepository<MsCompany> repCompany, IWebHostEnvironment webHostEnvironment,SettingBLL settingBLL)
        {
            _AccountBll = AccountBll;
            _ShiftBLL = shiftBLL;
            _StoreBLL = storeBLL;
            _repCompany = repCompany;
            _webHostEnvironment = webHostEnvironment;
            _settingBLL = settingBLL;
        }
        [Authorize]
        public IActionResult Index()
        {

            return View();
        }


        [Authorize]
        public IActionResult Company()
        {

            MsCompany compay = _repCompany.GetAll().FirstOrDefault();
            if (compay==null)
            {
                compay = new MsCompany {CompNameA="شركة ",CompNameE="Company",Code=int.Parse( "".UniqueNumber()) };
                _repCompany.Insert(compay);
                _settingBLL.UpdateCompanyBaseData(long.Parse("".UniqueNumber()), "", "", "شركة");
            }
            return View(compay);
        }

        public IActionResult UpdateCompany(MsCompany msCompany)
        {


            var entity = _repCompany.GetById(msCompany.CompanyId);
            if (entity != null)
            {
                var file = HttpContext.Request.Form.Files;
                if (file != null && file.Count > 0)
                {
                    var f = file[0];
                    string path = System.IO.Path.GetRandomFileName().Replace(".", "") + System.IO.Path.GetExtension(f.FileName);
                    string FullPath = _webHostEnvironment.WebRootPath + "/Upload/" + path;
                    using (var fileStream = new FileStream(FullPath, FileMode.CreateNew))
                    {
                        f.CopyTo(fileStream);
                        fileStream.Dispose();
                    }
                    msCompany.LogoUrl = path;
                }
                entity.Code = long.Parse("".UniqueNumber());
                entity.CompNameA = msCompany.CompNameA;
                entity.CompNameE = msCompany.CompNameE;
                entity.Tel1 = msCompany.Tel1;
                entity.Tel2 = msCompany.Tel2;
                entity.Email = msCompany.Email;
                entity.Email1 = msCompany.Email1;
                entity.Address = msCompany.Address;
                entity.Website = msCompany.Website;
            


                var action = _repCompany.Update(entity);
                _settingBLL.UpdateCompanyBaseData(entity.Code.Value, entity.LogoUrl, "", entity.CompNameA);
                return Json(new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم التعديل بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                });
            }
            else
                return Json(new
                {
                    Status = 500,
                    message = "حدث خطأ ما اعد المحاولة"
                });
        }


        public IActionResult Qr()
        {
            //   ViewData["shifts"] =new SelectList( _ShiftBLL.Shifts(), "ShiftId", "Name1");
            ViewData["stores"] = _StoreBLL.Stores();
            return View();
        }

        public JsonResult getNewQr(int storeId)
        {
            return Json(_AccountBll.GetQrCode(storeId, 300, 300));
        }
    }
}
