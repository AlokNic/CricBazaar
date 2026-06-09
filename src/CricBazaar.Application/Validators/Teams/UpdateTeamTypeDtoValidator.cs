using CricBazaar.Application.DTOs.Teams;
using FluentValidation;

namespace CricBazaar.Application.Validators.Teams
{
    public class UpdateTeamTypeDtoValidator: AbstractValidator<UpdateTeamTypeDto>
    {
        public UpdateTeamTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}