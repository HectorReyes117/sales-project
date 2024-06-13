using FluentValidation;
using Sales.Application.Dtos.CategoriesDto;

namespace Sales.Application.Validations.CategoriaValidations;

public class CategoriaCreationDtoValidator : AbstractValidator<CategoriaCreationDto>
{
    public CategoriaCreationDtoValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotNull()
                .WithMessage("La Descripción no puede ser nula")
            .NotEmpty()
                .WithMessage("La Descripción no puede estar vacía");

        RuleFor(x => x.EsActivo)
            .NotNull()
            .WithMessage("Activo no puede ser nulo");
    }
}