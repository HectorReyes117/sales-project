using FluentValidation;
using Sales.WebApp.Models.Producto;

namespace Sales.WebApp.Validations.ProductoValidations;

public class ProductoCreationViewModelValidation : AbstractValidator<ProductoCreationViewModel>
{
    public ProductoCreationViewModelValidation()
    {
        RuleFor(v => v.Marca)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacío");
        
        RuleFor(v => v.Descripcion)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacío");
        
        RuleFor(x => x.IdCategoria)
            .NotNull()
            .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
            .WithMessage("El id debe ser mayor que cero");
        
        RuleFor(v => v.Stock)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacío");
        
        RuleFor(x => x.Precio)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Debe ser mayor o igual a 0")
            .NotNull()
            .WithMessage("No puede ser nulo");
        
        RuleFor(x => x.EsActivo)
            .NotNull()
            .WithMessage("No puede ser nulo");
    }
}