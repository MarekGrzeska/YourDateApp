using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Commands.UpdateUserProfile;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Queries.GetAllUserProfiles;
using YourDateApp.Application.Queries.GetUserProfileByUsername;

namespace YourDateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private bool IsLoggedIn()
        {
            var user = HttpContext.User;
            if (user == null || user.Identity == null) return false;
            return user.Identity.IsAuthenticated;
        }

        private string GetCurrentUsername()
        {
            return HttpContext!.User!.Identity!.Name!;
        }

        public async Task<IActionResult> ProfilesBrowser()
        {
            if (!IsLoggedIn()) return RedirectToAction("Login", "Account");

            var profiles = await _mediator.Send(new GetAllUserProfilesQuery());
            profiles = profiles.Where(p => p.Username != GetCurrentUsername()).ToList();
            return View(profiles);
        }

        public async Task<IActionResult> Index()
        {
            UserProfileDto dto;
            if (! IsLoggedIn()) return RedirectToAction("Login", "Account");

            var username = HttpContext!.User!.Identity!.Name!;
            dto = await _mediator.Send(new GetUserProfileByUsernameQuery(username));

            var updateUserProfileCommand = _mapper.Map<UpdateUserProfileCommand>(dto);
            return View(updateUserProfileCommand); ;
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserProfileCommand command)
        {
            if (!ModelState.IsValid) return View(command);
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }
    }
}