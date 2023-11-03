using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : UserProfileDto, IRequest
    {
    }
}
