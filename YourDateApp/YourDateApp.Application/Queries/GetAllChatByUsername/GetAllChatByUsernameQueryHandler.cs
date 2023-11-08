using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.GetAllChatByUsername
{
    public class GetAllChatByUsernameQueryHandler : IRequestHandler<GetAllChatByUsernameQuery, List<ChatDto>>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public GetAllChatByUsernameQueryHandler(IChatRepository chatRepository, IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task<List<ChatDto>?> Handle(GetAllChatByUsernameQuery request, CancellationToken cancellationToken)
        {
            var chats = await _chatRepository.GetAllChats(request.Username);
            if (chats == null || chats.Count == 0) return null;

            var chatsDto = new List<ChatDto>();
            foreach (var chat in chats)
            {
                var dto = new ChatDto()
                {
                    UsernameChatWith = chat.Username1 == request.Username ? chat.Username2 : chat.Username1,
                };
                var user = await _userRepository.GetByUsername(dto.UsernameChatWith);
                dto.UsernameChatWithPhotoSrc = user!.Profile != null ? user.Profile!.PhotoSrc! : null;

                var messages = await _messageRepository.GetAllMessagesForChatId(chat.Id);
                dto.NewMessageAmount = messages!
                    .Count(m => m.UsernameTo == request.Username && m.IsReceived == false);
                dto.LastMessageDate = messages.OrderByDescending(m => m.SentDate).First().SentDate;
                chatsDto.Add(dto);
            }
            return chatsDto.OrderByDescending(c => c.LastMessageDate).ToList();
        }
    }
}
