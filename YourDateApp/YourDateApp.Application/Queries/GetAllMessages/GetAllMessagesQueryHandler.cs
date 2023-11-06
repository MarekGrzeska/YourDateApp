using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetAllMessages
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, List<MessageDto>>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetAllMessagesQueryHandler(IChatRepository chatRepository, 
            IMessageRepository messageRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.FindChatWithUsers(request.UsernameFrom, request.UsernameTo);
            if (chat == null) return null;

            var messages = await _messageRepository.GetAllMessagesForChatId(chat.Id);
            return _mapper.Map<List<MessageDto>>(messages);
        }
    }
}