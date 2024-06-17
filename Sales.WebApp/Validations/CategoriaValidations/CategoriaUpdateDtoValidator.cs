using FluentValidation;
using Sales.Application.Dtos.CategoriesDto;

namespace Sales.WebApp.Validations.CategoriaValidations;

public class CategoriaUpdateDtoValidator : AbstractValidator<CategoriaUpdateDto>
{
    public CategoriaUpdateDtoValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotNull()
                .WithMessage("La Descripción no puede ser nula")
            .NotEmpty()
                .WithMessage("La Descripción no puede estar vacía");

        RuleFor(x => x.EsActivo)
            .NotNull()
            .WithMessage("No puede ser nulo");

        RuleFor(x => x.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
    }
}