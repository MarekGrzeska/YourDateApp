using MediatR;
using YourDateApp.Application.Dtos;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Application.Queries.LoginUser
{
    public class LoginUserQuery : LoginDto ,IRequest<User?>
    {
    }
}
