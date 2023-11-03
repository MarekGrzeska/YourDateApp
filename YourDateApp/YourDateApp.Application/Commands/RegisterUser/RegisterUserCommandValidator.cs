using FluentValidation;
using YourDateApp.Domain.Interfaces;

namespace YourDateApp.Application.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(IUserRepository repository) 
        {
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Adres email nie może być pusty")
                .EmailAddress().WithMessage("Adres email jest nieprawidłowy")
                .Custom((value, context) =>
                {
                    var user = repository.GetByEmail(value).Result;
                    if (user != null)
                    {
                        context.AddFailure($"Adres email {value} jest już zajęty");
                    }
                });

            RuleFor(r => r.Username)
                .NotEmpty().WithMessage("Nazwa użytkownika nie może być pusta")
                .MinimumLength(5).WithMessage("Nazwa użytkownika musi mieć minimum 5 znaków")
                .MaximumLength(30).WithMessage("Nazwa użytkownika musi mieć maksimum 30 znaków")
                .Custom((value, context) =>
                {
                    var user = repository.GetByUsername(value).Result;
                    if (user != null)
                    {
                        context.AddFailure($"Nazwa użytkownika {value} jest już zajęta");
                    }
                });

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Hasło nie może być puste")
                .MinimumLength(5).WithMessage("Hasło musi mieć minimum 5 znaków")
                .MaximumLength(50).WithMessage("Nazwa użytkownika musi mieć maksimum 30 znaków");

            RuleFor(r => r.Password2)
                .NotEmpty().WithMessage("Powtórzone hasło nie może być puste")
                .MinimumLength(5).WithMessage("Powtórzone hasło musi mieć minimum 5 znaków")
                .MaximumLength(30).WithMessage("Powtórzone hasło musi mieć maksimum 30 znaków")
                .Equal(r => r.Password).WithMessage("Wpisane hasła nie są takie same");
        }
    }
}
