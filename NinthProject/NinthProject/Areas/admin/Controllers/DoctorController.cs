using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Contexts;
using Project.DAL.Exceptions;

namespace NinthProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class DoctorController : Controller
    {
        private readonly NinthDbContext _context;
        private readonly IDoctorService _service;

        public DoctorController(NinthDbContext context, IDoctorService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allDoctor=await _service.GetAllAsync();
            return View(allDoctor);
        }
        public async Task<IActionResult> Info(int id)
        {
            try
            {
                var oneDoctor = await _service.GetOneByIdAsync(id);
            return View(oneDoctor);

            }
            catch (BaseException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest("Something Went Wrong");
            }
        }
        public IActionResult Create()
        {
            ViewBag.Treatment=_context.treatments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateDto dto)
        {
            ViewBag.Treatment = _context.treatments;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.CreateAsync(dto);
                

            }
            catch (BaseException ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
            }
            catch (Exception)
            {

                ModelState.AddModelError("CustomError","Doctor Not Found");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            ViewBag.Treatment = _context.treatments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,DoctorCreateDto dto)
        {
            ViewBag.Treatment = _context.treatments;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.UpdateAsync(id,dto);


            }
            catch (BaseException ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
            }
            catch (Exception)
            {

                ModelState.AddModelError("CustomError", "Doctor Not Found");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
              
                await _service.DeleteAsync(id);
              
            return RedirectToAction("Index");

            }
            catch (BaseException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest("Something Went Wrong");
            }
        }

    }
}
