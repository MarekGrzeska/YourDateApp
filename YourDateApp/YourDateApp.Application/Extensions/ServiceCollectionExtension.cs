using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YourDateApp.Application.Commands.RegisterUser;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterUserCommand));
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }
    }
}
