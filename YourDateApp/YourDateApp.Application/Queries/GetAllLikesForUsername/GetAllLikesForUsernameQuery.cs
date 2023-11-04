using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetAllLikesForUsername
{
    public class GetAllLikesForUsernameQuery : IRequest<UserLikesDto>
    {
        public string Username { get; set; }
        public GetAllLikesForUsernameQuery(string username)
        {
            Username = username;
        }
    }
}