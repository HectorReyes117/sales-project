using FluentValidation;
using Sales.Application.Dtos.TipoDocumentoVentaDto;
using Sales.Domain.Interfaces;

namespace Sales.Application.Validations.TipoDocumentoVentaValidations;

public class TipoDocumentoVentaUpdateDtoValidation : AbstractValidator<TipoDocumentoVentaUpdateDto>
{
    public TipoDocumentoVentaUpdateDtoValidation(
        ITipoDocumentoVentaRepository tipoDocumentoVentaRepository
        )
    {
        RuleFor(x => x.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero")
            .MustAsync(async (id, cancellationToken) =>
            {
                return !(await tipoDocumentoVentaRepository.Exist(x => x.Id == id));
            }).WithMessage("El documento no existe no existe");
        
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