using FluentValidation;
using Sales.Application.Dtos.ProductoDto;
using Sales.Domain.Interfaces;

namespace Sales.Application.Validations.ProductoValidations;

public class ProductoUpdateDtoValidation : AbstractValidator<ProductoUpdateDto>
{
    public ProductoUpdateDtoValidation(
        IProductoRepository productoRepository,
        ICategoriaRepository categoriaRepository
        )
    {
        RuleFor(x => x.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
        
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