using CricBazaar.Application.DTOs.Auth;
using FluentValidation;

namespace CricBazaar.Application.Validators.Auth
{
    public class LoginDtoValidator
        : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}