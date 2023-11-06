using MediatR;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;

        public SendMessageCommandHandler(IChatRepository chatRepository, IMessageRepository messageRepository)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.
                FindChatWithUsers(request.Message.UsernameFrom, request.Message.UsernameTo);

            if (chat == null) 
            {
                chat = new Chat()
                {
                    Username1 = request.Message.UsernameFrom,
                    Username2 = request.Message.UsernameTo,
                };
                await _chatRepository.AddChat(chat);
                chat = await _chatRepository.
                FindChatWithUsers(request.Message.UsernameFrom, request.Message.UsernameTo);
            }

            var message = new Message()
            {
                ChatId = chat.Id,
                Content = request.Message.Content,
                UsernameFrom = request.Message.UsernameFrom,
                UsernameTo = request.Message.UsernameTo,
                SentDate = DateTime.Now,
                IsReceived = false,
            };
            await _messageRepository.AddMessage(message);

            return Unit.Value;
        }
    }
}