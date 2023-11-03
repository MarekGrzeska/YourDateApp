using MediatR;
using Microsoft.AspNetCore.Identity;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User?>
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(IPasswordHasher<User> password,  IUserRepository userRepository)
        {
            _passwordHasher = password;
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null) return null;
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed) return null;
            return user;
        }
    }
}