using CricBazaar.Application.DTOs.Players;
using FluentValidation;

namespace CricBazaar.Application.Validators.Players
{
    public class UpdatePlayerRoleDtoValidator: AbstractValidator<UpdatePlayerRoleDto>
    {
        public UpdatePlayerRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}