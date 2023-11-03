using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Commands.RegisterUser;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account"); ;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid) return View();
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return View();

            return RedirectToAction("Index", "Home");
        }
    }
}