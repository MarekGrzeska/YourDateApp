using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetAllChatByUsername
{
    public class GetAllChatByUsernameQuery : IRequest<List<ChatDto>?>
    {
        public string Username { get; set; }

        public GetAllChatByUsernameQuery(string username)
        {
            Username = username;
        }   
    }
}