using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Commands.UpdateUserProfile;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Queries.GetAllUserProfiles;
using YourDateApp.Application.Queries.GetUserProfileByUsername;
using YourDateApp.Extension;

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

        public async Task<IActionResult> ProfilesBrowser()
        {
            if (!this.IsLoggedIn()) return RedirectToAction("Login", "Account");

            var profiles = await _mediator.Send(new GetAllUserProfilesQuery());
            profiles = profiles.Where(p => p.Username != this.GetCurrentUsername()).ToList();
            return View(profiles);
        }

        [Route("Home/Profile/{username}")]
        public async Task<IActionResult> Profile(string username)
        {
            if (!this.IsLoggedIn()) return RedirectToAction("Login", "Account");

            var dto = await _mediator.Send(new GetUserProfileByUsernameQuery(username));
            return View(dto);
        }

        public async Task<IActionResult> Index()
        {
            UserProfileDto dto;
            if (! this.IsLoggedIn()) return RedirectToAction("Login", "Account");

            var username = HttpContext!.User!.Identity!.Name!;
            dto = await _mediator.Send(new GetUserProfileByUsernameQuery(username));
            if (dto == null) return RedirectToAction("Login", "Account");

            var updateUserProfileCommand = _mapper.Map<UpdateUserProfileCommand>(dto);
            return View(updateUserProfileCommand); ;
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserProfileCommand command)
        {
            if (!ModelState.IsValid)
            {
                this.SetNotyfication("Błąd aktualizacji profilu", "error");
                var dto = await _mediator.Send(new GetUserProfileByUsernameQuery(command.Username));
                command.PhotoSrc = dto.PhotoSrc;
                return View(command);
            }

            await _mediator.Send(command);
            this.SetNotyfication("Zaktualizowano profil", "info");
            return RedirectToAction("Index", "Home");
        }
    }
}