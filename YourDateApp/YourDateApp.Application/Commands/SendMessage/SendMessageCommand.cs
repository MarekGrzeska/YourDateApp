using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Commands.SendMessage
{
    public class SendMessageCommand : IRequest
    {
        public MessageDto Message { get; set; }

        public SendMessageCommand(MessageDto message)
        {
            Message = message;
        }
    }
}
