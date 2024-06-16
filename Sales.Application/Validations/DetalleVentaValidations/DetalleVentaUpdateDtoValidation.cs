using FluentValidation;
using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Domain.Interfaces;

namespace Sales.Application.Validations.DetalleVentaValidations;

public class DetalleVentaUpdateDtoValidation : AbstractValidator<DetalleVentaUpdateDto>
{
    // Todo create validations and use in validations of venta
    public DetalleVentaUpdateDtoValidation(
        IDetalleVentaRepository detalleVentaRepository,
        IVentaRepository ventaRepository,
        IProductoRepository productoRepository
        )
    {
        RuleFor(v => v.Id)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero")
            .MustAsync(async (id, _) =>
            {
                return !(await detalleVentaRepository.Exist(x => x.Id == id));
            }).WithMessage("El detalle de la venta no existe");
        
        RuleFor(v => v.IdVenta)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero")
            .MustAsync(async (id, _) =>
            {
                return !(await ventaRepository.Exist(x => x.Id == id));
            }).WithMessage("La venta no existe");
        
        RuleFor(v => v.IdProducto)
            .NotNull()
                .WithMessage("No puede estar nulo")
            .GreaterThan(0)
                .WithMessage("No debe ser mayor que cero")
            .MustAsync(async (id, _) =>
            {
                return !(await productoRepository.Exist(x => x.Id == id));
            }).WithMessage("El producto no existe");
        
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