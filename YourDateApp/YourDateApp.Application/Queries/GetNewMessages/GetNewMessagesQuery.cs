using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetNewMessages
{
    public class GetNewMessagesQuery : IRequest<List<MessageDto>>
    {
        public string UsernameFrom { get; set; }
        public string UsernameTo { get; set; }

        public GetNewMessagesQuery(string usernameFrom, string usernameTo)
        {
            UsernameFrom = usernameFrom;
            UsernameTo = usernameTo;
        }
    }
}