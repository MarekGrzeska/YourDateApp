using FluentValidation;

namespace YourDateApp.Application.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(p => p.Age)
                .GreaterThan(0).WithMessage("Wiek musi być większy od 0");

            RuleFor(p => p.FirstName)
                .MinimumLength(3).WithMessage("Imię musi mieć minimum 3 znaki");

            RuleFor(p => p.LastName)
                .MinimumLength(3).WithMessage("Nazwisko musi mieć minimum 3 znaki");

            RuleFor(p => p.City)
                .MinimumLength(3).WithMessage("Miasto musi mieć minimum 3 znaki");

            RuleFor(p => p.Country)
                .MinimumLength(3).WithMessage("Kraj musi mieć minimum 3 znaki");
        }
    }
}