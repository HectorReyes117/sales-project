using FluentValidation;
using Sales.WebApp.Models.TipoDocumentoVenta;

namespace Sales.WebApp.Validations.TipoDocumentoVentaValidations;

public class TipoDocumentoVentaCreationDtoValidation : AbstractValidator<TipoDocumentoVentaCreationViewModel>
{
    public TipoDocumentoVentaCreationDtoValidation()
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