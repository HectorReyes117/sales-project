using FluentValidation;
using Sales.Application.Dtos.VentaDto;
using Sales.Application.Validations.DetalleVentaValidations;
using Sales.Domain.Interfaces;

namespace Sales.Application.Validations.VentaValidations;

public class VentaCreationDtoValidation : AbstractValidator<VentaCreationDto>
{
    // Todo refactoring to reuse in VentaUpdateDtoValidation
    public VentaCreationDtoValidation(
        IDetalleVentaRepository detalleVentaRepository,
        IVentaRepository ventaRepository,
        IProductoRepository productoRepository
        )
    {
        RuleFor(v => v.NumeroVenta)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.IdTipoDocumentoVenta)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("Debe ser mayor que cero");
        
        RuleFor(v => v.IdUsuario)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("Debe ser mayor que cero");
        
        RuleFor(v => v.CocumentoCliente)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.NombreCliente)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");

        RuleFor(v => v.SubTotal)
            .NotNull()
                .WithMessage("No puede ser nulo")
            .GreaterThanOrEqualTo(0)
                .WithMessage("Debe ser mayor o igual a cero");
        
        RuleFor(v => v.ImpuestoTotal)
            .NotNull()
                .WithMessage("No puede ser nulo")
            .GreaterThanOrEqualTo(0)
                .WithMessage("Debe ser mayor o igual a cero");
        
        RuleFor(v => v.Total)
            .NotNull()
                .WithMessage("No puede ser nulo")
            .GreaterThanOrEqualTo(0)
                .WithMessage("Debe ser mayor o igual a cero");
        
        RuleForEach(v => v.DetalleVenta)
            .SetValidator(new DetalleVentaCreationDtoValidation(ventaRepository, productoRepository));
    }
}