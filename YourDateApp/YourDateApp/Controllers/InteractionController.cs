using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Commands.SendLike;
using YourDateApp.Extension;

namespace YourDateApp.Controllers
{
    public class InteractionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InteractionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendLike(string username)
        {
            if (!this.IsLoggedIn())
            {
                this.SetNotyfication("Błąd podczas wysyłania polubienia", "error");
                return RedirectToAction("Login", "Account");
            }
            var currentUsername = this.GetCurrentUsername();
            await _mediator.Send(new SendLikeCommand(currentUsername, username));
            this.SetNotyfication($"Wysłano polubienie do {username}", "info");

            return RedirectToAction($"Profile", "Home", new { username = username });
        }
    }
}