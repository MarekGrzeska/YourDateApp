using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourDateApp.Application.Commands.SendLike;
using YourDateApp.Application.Commands.SendMessage;
using YourDateApp.Application.Commands.SetLikesReceived;
using YourDateApp.Application.Commands.SetMessagesReceived;
using YourDateApp.Application.Dtos;
using YourDateApp.Application.Queries.GetAllLikesForUsername;
using YourDateApp.Application.Queries.GetAllMessages;
using YourDateApp.Application.Queries.GetUnreceivedLikesCount;
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

        public async Task<IActionResult> MyLikes()
        {
            if (!this.IsLoggedIn()) return RedirectToAction("Login", "Account");
            var currentUsername = this.GetCurrentUsername();
            var myLikes = await _mediator.Send(new GetAllLikesForUsernameQuery(currentUsername));
            if (myLikes.ReceivedLikes != null && myLikes.ReceivedLikes.Count > 0 &&
                myLikes.ReceivedLikes.Any(l => l.IsReceived == false))
            {
                await _mediator.Send(new SetLikesReceivedCommand(currentUsername));
            }
            return View(myLikes);
        }

        public async Task<IActionResult> Chat()
        {
            return View();
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

        [HttpGet]
        [Route("Interaction/UnreceivedLikeCount/{username}")]
        public async Task<IActionResult> UnreceivedLikeCount(string username)
        {
            if (!this.IsLoggedIn())
                return Unauthorized();

            var unreceivedLikeCount = await _mediator.Send(new GetUnreceivedLikesCountQuery(username));
            return Ok(unreceivedLikeCount);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto messageDto)
        {
            if (!this.IsLoggedIn())
                return Unauthorized();

            await _mediator.Send(new SendMessageCommand(messageDto));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage(GetMessagesDto getMessagesDto)
        {
            if (!this.IsLoggedIn())
                return Unauthorized();

            var messages = await _mediator
                .Send(new GetAllMessagesQuery(getMessagesDto.UsernameFrom, getMessagesDto.UsernameTo));

            if (messages != null && messages.Count > 0 && messages.Any(m => m.IsReceived == false))
            {
                // czyscimy wiadomości przychodzace do nas
                // odwrotnie niż wyysła skrypt JS gdzie usernameFrom = nasz użytkownik
                await _mediator.Send(new SetMessagesReceivedCommand(getMessagesDto.UsernameTo,
                    getMessagesDto.UsernameFrom));
            }

            return Ok(messages);
        }
    }
}