using Microsoft.AspNetCore.Mvc;

namespace NinthProject.Areas.admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
