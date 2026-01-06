using FluentValidation;
using api.Models;

namespace api.Validators;

public class CharacterValidator : AbstractValidator<Character>
{
    public CharacterValidator()
    {
        RuleFor(c => c.Name)
        .NotEmpty().WithMessage("Name not Empty")
        .NotNull().WithMessage("Name is required")
        .Length(3, 50).WithMessage("Name Length between 3 and 50");

        RuleFor(c => c.Surname)
        .NotEmpty().WithMessage("Surname not Empty")
        .Length(3, 50).WithMessage("Surname Length between 3 and 50");

        RuleFor(c => c.IdGender).NotEmpty().NotNull().WithMessage("IdGender is required");
        RuleFor(c => c.IdPhrases).NotEmpty().NotNull().WithMessage("IdPhrases is required");
        RuleFor(c => c.PathImage).NotEmpty().NotNull().WithMessage("PathImage is required");
        RuleFor(c => c.DateBirthDay).NotEmpty().NotNull().WithMessage("DateBirthDay is required");
    }
}



