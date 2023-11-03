using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Queries.GetAllUserProfiles
{
    public class GetAllUserProfilesQuery : IRequest<IEnumerable<UserProfileDto>>
    {
    }
}
