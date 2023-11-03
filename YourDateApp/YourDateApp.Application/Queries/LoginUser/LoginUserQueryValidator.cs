using FluentValidation;
using Microsoft.AspNetCore.Identity;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator(IUserRepository repository, IPasswordHasher<User> passwordHasher) 
        {
            User? user = null;

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Adres email nie może być pusty")
                .EmailAddress().WithMessage("Adres email jest nieprawidłowy")
                .Custom((value, context) =>
                {
                    user = repository.GetByEmail(value).Result;
                });

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Hasło nie może być puste")
                .Custom((value, context) =>
                {
                    if (user == null)
                    {
                        context.AddFailure($"Adres email lub hasło są nieprawidłowe");
                    }
                    else
                    {
                        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, value!);
                        if (result == PasswordVerificationResult.Failed)
                        {
                            context.AddFailure($"Adres email lub hasło są nieprawidłowe");
                        }
                    }
                });
        }
    }
}
