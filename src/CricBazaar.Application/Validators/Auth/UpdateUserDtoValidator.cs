using CricBazaar.Application.DTOs.Users;
using FluentValidation;

namespace CricBazaar.Application.Validators.Users
{
    public class UpdateUserDtoValidator: AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Phone).MaximumLength(20);
        }
    }
}