using AutoMapper;
using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetNewMessages
{
    public class GetNewMessagesQueryHandler : IRequestHandler<GetNewMessagesQuery, List<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetNewMessagesQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> Handle(GetNewMessagesQuery request, CancellationToken cancellationToken)
        {
            var mesages = await _messageRepository.GetNewMessages(request.UsernameFrom, request.UsernameTo);
            var msgDtos = _mapper.Map<List<MessageDto>>(mesages);
            return msgDtos;
        }
    }
}
