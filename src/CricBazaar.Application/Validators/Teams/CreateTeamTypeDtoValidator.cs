using CricBazaar.Application.DTOs.Teams;
using FluentValidation;

namespace CricBazaar.Application.Validators.Teams
{
    public class CreateTeamTypeDtoValidator: AbstractValidator<CreateTeamTypeDto>
    {
        public CreateTeamTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}