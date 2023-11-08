using MediatR;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.SetMessagesReceived
{
    public class SetMessagesReceivedCommandHandler : IRequestHandler<SetMessagesReceivedCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public SetMessagesReceivedCommandHandler(IMessageRepository messageRepository) 
        {
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SetMessagesReceivedCommand request, CancellationToken cancellationToken)
        {
            await _messageRepository.SetMessageReceived(request.UsernameFrom, request.UsernameTo);
            return Unit.Value;
        }
    }
}