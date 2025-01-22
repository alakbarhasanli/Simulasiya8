using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace NinthProject.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
