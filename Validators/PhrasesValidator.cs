using FluentValidation;
using api.Models;

namespace api.Validators;

public class PhrasesValidator : AbstractValidator<Phrases>
{
    public PhrasesValidator()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage("Phrase is required");
        RuleFor(x => x.IdCharacter)
        .NotEmpty()
        .GreaterThan(0)
        .WithMessage("Character is required");
    }
}






