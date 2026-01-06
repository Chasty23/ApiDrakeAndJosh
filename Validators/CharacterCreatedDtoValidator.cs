using FluentValidation;
using api.Dtos;

namespace api.Validators;

public class CharacterCreatedDtoValidator : AbstractValidator<CharacterCreatedDto>
{
    public CharacterCreatedDtoValidator()
    {
        RuleFor(c => c.Name)
        .NotEmpty().WithMessage("Name not Empty")
        .NotNull().WithMessage("Name is required")
        .Length(3, 50).WithMessage("Name Length between 3 and 50");

        RuleFor(c => c.Surname)
        .NotEmpty().WithMessage("Surname not Empty")
        .NotNull().WithMessage("Surname is required")
        .Length(3, 50).WithMessage("Surname Length between 3 and 50");

        RuleFor(c => c.IdGender)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0).WithMessage("IdGender must be greater than 0")
        .WithMessage("IdGender is required");

        RuleFor(c => c.IdPhrases)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0).WithMessage("IdPhrases must be greater than 0")
        .WithMessage("IdPhrases is required");
        RuleFor(c => c.PathImage).NotEmpty().NotNull().WithMessage("PathImage is required");
    }
}