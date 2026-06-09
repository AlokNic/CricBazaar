using CricBazaar.Application.DTOs.Players;
using FluentValidation;

namespace CricBazaar.Application.Validators.Players
{
    public class CreatePlayerDtoValidator
        : AbstractValidator<CreatePlayerDto>
    {
        public CreatePlayerDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.PlayerRoleId)
                .GreaterThan(0);
        }
    }
}