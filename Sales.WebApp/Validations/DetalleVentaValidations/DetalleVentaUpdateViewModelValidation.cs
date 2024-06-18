using FluentValidation;
using Sales.WebApp.Models.DetalleVenta;

namespace Sales.WebApp.Validations.DetalleVentaValidations;

public class DetalleVentaUpdateViewModelValidation : AbstractValidator<DetalleVentaUpdateViewModel>
{
    public DetalleVentaUpdateViewModelValidation()
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero");
        
        RuleFor(v => v.IdVenta)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero");
        
        RuleFor(v => v.IdProducto)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero");
        
        RuleFor(v => v.MarcaProducto)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.DescripcionProducto)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.CategoriaProducto)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .NotEmpty()
                .WithMessage("No puede estar vacía");
        
        RuleFor(v => v.Cantidad)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero");
        
        RuleFor(v => v.Precio)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero");
        
        RuleFor(v => v.Total)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("Debe ser mayor que cero");
    }
}