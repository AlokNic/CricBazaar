using CricBazaar.Application.DTOs.Teams;
using FluentValidation;

namespace CricBazaar.Application.Validators.Teams
{
    public class UpdateTeamDtoValidator: AbstractValidator<UpdateTeamDto>
    {
        public UpdateTeamDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.ShortName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.TeamTypeId)
                .GreaterThan(0);
        }
    }
}