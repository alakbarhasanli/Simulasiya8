using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Contexts;
using Project.DAL.Exceptions;

namespace NinthProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _service;

        public TreatmentController( ITreatmentService service)
        {
           
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allTreatment = await _service.GetAllAsync();
            return View(allTreatment);
        }
        public async Task<IActionResult> Info(int id)
        {
            try
            {
                var oneTreatment = await _service.GetOneByIdAsync(id);
                return View(oneTreatment);

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
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TreatmentCreateDto dto)
        {
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

                ModelState.AddModelError("CustomError", "Doctor Not Found");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TreatmentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.UpdateAsync(id, dto);


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
