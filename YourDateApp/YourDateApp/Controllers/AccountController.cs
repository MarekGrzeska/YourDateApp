using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourDateApp.Application.Commands.RegisterUser;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Queries.LoginUser;

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
            await LoginUser(new LoginUserQuery { Email = command.Email, Password = command.Password });
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            if (!ModelState.IsValid) return View();
            var loginResult = await LoginUser(query);
            if (!loginResult) return View();

            return RedirectToAction("Index", "Home");
        }

        private async Task<bool> LoginUser(LoginUserQuery query)
        {
            var user = await _mediator.Send(query);
            if (user == null) return false;

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Gender, user.Gender),
            };
            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = false,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return true;
        }
    }
}