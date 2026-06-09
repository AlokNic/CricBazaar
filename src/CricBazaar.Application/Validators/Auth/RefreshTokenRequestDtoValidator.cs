using CricBazaar.Application.DTOs.Auth;
using FluentValidation;

namespace CricBazaar.Application.Validators.Auth
{
    public class RefreshTokenRequestDtoValidator
        : AbstractValidator<RefreshTokenRequestDto>
    {
        public RefreshTokenRequestDtoValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}