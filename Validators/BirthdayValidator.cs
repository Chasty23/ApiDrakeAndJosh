using FluentValidation;
using api.Models;

namespace api.Validators;

public class BirthDayValidator : AbstractValidator<BirthDay>
{
    public BirthDayValidator()
    {
        RuleFor(b => b.Day)
        .NotEmpty().WithMessage("Day not Empty")
        .NotNull().WithMessage("Day is required")
        .InclusiveBetween(1, 31).WithMessage("Day must be between 1 and 31");

        RuleFor(b => b.Month)
        .NotEmpty().WithMessage("Month not Empty")
        .NotNull().WithMessage("Month is required")
        .InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12");
        // VALIDACIÓN CRUZADA:
        RuleFor(b => b)
            .Must(BeAValidDate)
            .WithMessage("La combinación de día y mes no existe (ej: 31 de Febrero)");
    }
    private bool BeAValidDate(BirthDay birthday)
    {
        // Si alguno es nulo, dejamos que las reglas de arriba manejen el error
        if (!birthday.Day.HasValue || !birthday.Month.HasValue)
            return true;

        try
        {
            // Intentamos crear una fecha real usando un año cualquiera que no sea bisiesto 
            // (ej: 2023) para validar la lógica de los meses.
            // Si quieres soportar bisiestos (29 feb), usa un año bisiesto como 2024.
            var tempDate = new DateTime(2024, birthday.Month.Value, birthday.Day.Value);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false; // Si falla, es porque el día no corresponde al mes
        }
    }
}


