using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetUserProfileByUsername
{
    public class GetUserProfileByUsernameQuery : IRequest<UserProfileDto>
    {
        public string Username { get; set; }

        public GetUserProfileByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}