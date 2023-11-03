using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Queries.GetUserProfileByUsername;

namespace YourDateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private bool IsLoggedIn()
        {
            var user = HttpContext.User;
            if (user == null || user.Identity == null) return false;
            return user.Identity.IsAuthenticated;
        }

        public async Task<IActionResult> Index()
        {
            UserProfileDto dto;
            if (! IsLoggedIn()) return RedirectToAction("Login", "Account");

            var username = HttpContext!.User!.Identity!.Name!;
            dto = await _mediator.Send(new GetUserProfileByUsernameQuery(username));

            return View(dto); ;
        }
    }
}