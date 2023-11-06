using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetAllMessages
{
    public class GetAllMessagesQuery : IRequest<List<MessageDto>>
    {
        public string UsernameFrom { get; set; }
        public string UsernameTo { get; set; }

        public GetAllMessagesQuery(string usernameFrom, string usernameTo)
        {
            UsernameFrom = usernameFrom;
            UsernameTo = usernameTo;
        }
    }
}