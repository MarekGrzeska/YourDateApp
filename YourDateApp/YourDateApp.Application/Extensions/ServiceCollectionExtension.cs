using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YourDateApp.Application.Commands.RegisterUser;
using YourDateApp.Application.Mappings;
using YourDateApp.Application.Queries.LoginUser;
using YourDateApp.Application.Services;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RegisterUserCommand));
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IProfilePhotoService, ProfilePhotoService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                });
            services.AddValidatorsFromAssemblyContaining<LoginUserQueryValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scoped = provider.CreateScope();
                cfg.AddProfile(new YourDateAppMappingProfile());
            }).CreateMapper());
        }
    }
}