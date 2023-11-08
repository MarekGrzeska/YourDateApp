using MediatR;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.SetNewMessagesReceived
{
    public class SetNewMessagesReceivedCommandHandler : IRequestHandler<SetNewMessagesReceivedCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public SetNewMessagesReceivedCommandHandler(IMessageRepository messageRepository) 
        {
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SetNewMessagesReceivedCommand request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetNewMessages(request.UsernameFrom, request.UsernameTo);
            foreach (var message in messages) 
            {
                message.IsReceived = true;
            }
            await _messageRepository.Commit();
            return Unit.Value;
        }
    }
}