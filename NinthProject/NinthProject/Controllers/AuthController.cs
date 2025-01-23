using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Exceptions;

namespace NinthProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {

            _service = service;
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAuthDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.RegisterAsync(dto);


            }
            catch (BaseException ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
            }
            catch (Exception)
            {

                ModelState.AddModelError("CustomError", "Credentials Not Found");
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginAuthDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _service.LoginAsync(dto);


            }
            catch (BaseException ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
            }
            catch (Exception)
            {

                ModelState.AddModelError("CustomError", "Credentials Not Found");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {

                await _service.LogoutAsync();

            }
            catch (BaseException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest("Something Went Wrong");
            }
                return RedirectToAction("Index","Home");
        }

    }
}
