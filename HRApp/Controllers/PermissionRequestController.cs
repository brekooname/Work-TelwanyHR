using Microsoft.AspNetCore.Mvc;

namespace HRApp.Controllers
{
    public class PermissionRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
