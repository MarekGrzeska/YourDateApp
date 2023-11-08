using MediatR;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetAllNewMessagesCount
{
    public class GetAllNewMessagesCountQueryHandler : IRequestHandler<GetAllNewMessagesCountQuery, int>
    {
        private IMessageRepository _messageRepository;

        public GetAllNewMessagesCountQueryHandler(IMessageRepository messageRepository) 
        {
            _messageRepository = messageRepository;
        }

        public async Task<int> Handle(GetAllNewMessagesCountQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetAllNewMessagesCount(request.Username);
        }
    }
}