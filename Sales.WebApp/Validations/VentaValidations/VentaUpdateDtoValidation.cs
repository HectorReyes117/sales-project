using FluentValidation;
using Sales.Application.Dtos.VentaDto;
using Sales.WebApp.Validations.DetalleVentaValidations;

namespace Sales.WebApp.Validations.VentaValidations;

public class VentaUpdateDtoValidation : AbstractValidator<VentaUpdateDto>
{
    public VentaUpdateDtoValidation()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
        
        RuleFor(v => v.NumeroVenta)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                 .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.IdTipoDocumentoVenta)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
        
        RuleFor(v => v.IdUsuario)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
        
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
            .SetValidator(new DetalleVentaUpdateDtoValidation());
    }
}