using MediatR;
using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : RegisterUserDto, IRequest
    {
    }
}
