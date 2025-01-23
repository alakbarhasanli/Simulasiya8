using Microsoft.AspNetCore.Mvc;
using NinthProject.ViewModel;
using Project.BL.Services.Abstractions;
using System.Diagnostics;

namespace NinthProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITreatmentService _service1;
        private readonly IDoctorService _service2;
        public HomeController(ITreatmentService service1, IDoctorService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }


        public async Task<IActionResult> Index()
        {
            HomeVm vm = new()
            {
                doctor = await _service2.GetAllAsync(),
                treatment = await _service1.GetAllAsync(),
            };
            return View(vm);
        }

      
    }
}
