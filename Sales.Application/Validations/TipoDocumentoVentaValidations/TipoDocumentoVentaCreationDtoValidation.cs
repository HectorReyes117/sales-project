using FluentValidation;
using Sales.Application.Dtos.TipoDocumentoVentaDto;

namespace Sales.Application.Validations.TipoDocumentoVentaValidations;

public class TipoDocumentoVentaCreationDtoValidation : AbstractValidator<TipoDocumentoVentaCreationDto>
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