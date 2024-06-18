using FluentValidation;
using Sales.WebApp.Models.Categories;

namespace Sales.WebApp.Validations.CategoriaValidations;

public class CategoriaCreationViewModelValidator : AbstractValidator<CategoriaCreationViewModel>
{
    public CategoriaCreationViewModelValidator()
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