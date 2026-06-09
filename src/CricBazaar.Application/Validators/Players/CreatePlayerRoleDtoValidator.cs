using CricBazaar.Application.DTOs.Players;
using FluentValidation;

namespace CricBazaar.Application.Validators.Players
{
    public class CreatePlayerRoleDtoValidator: AbstractValidator<CreatePlayerRoleDto>
    {
        public CreatePlayerRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}