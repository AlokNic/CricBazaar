using CricBazaar.Application.DTOs.Players;
using FluentValidation;

namespace CricBazaar.Application.Validators.Players
{
    public class UpdatePlayerDtoValidator
        : AbstractValidator<UpdatePlayerDto>
    {
        public UpdatePlayerDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.PlayerRoleId)
                .GreaterThan(0);
        }
    }
}