using MediatR;
using Microsoft.AspNetCore.Identity;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IPasswordHasher<User> passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Email = request.Email!,
                Username = request.Username!,
                Gender = request.Gender!,
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, request.Password!);
            newUser.PasswordHash = hashedPassword;
            await _userRepository.RegisterUser(newUser);
            return Unit.Value;
        }
    }
}