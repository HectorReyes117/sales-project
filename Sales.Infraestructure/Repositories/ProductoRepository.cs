using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly SalesContext _context;

    public ProductoRepository(SalesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ProductModel>> GetAllProductsByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            ArgumentException.ThrowIfNullOrEmpty("No puede buscar una categoria vacia.");
        }

        var products = await (
                from product in _context.Productos
                join categories in _context.Categoria
                    on product.IdCategoria equals categories.Id
                where categories.Descripcion == category
                select new ProductModel()
                {
                    Id = product.Id,
                    CodigoBarra = product.CodigoBarra,
                    Marca = product.Marca,
                    Stock = product.Stock,
                    NombreCategoria = product.Categoria.Descripcion
                }
        ).ToListAsync();
        
        return products;
    }
    
    public override async Task Save(Producto entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        
        if (!(await base.Exist(ct => ct.Descripcion == entity.Descripcion)))
        {
            throw new ProductException("El producto debe ser ùnico.");
        }
        
        await base.Save(entity);
    }

    public override async Task Save(List<Producto> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de productos no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new ProductException("La cantidad de productos debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(Producto entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List<Producto> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de productos no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new ProductException("La cantidad de productos debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public override async Task<Producto?> Get(int id)
    {
        var product = await base.Get(id);

        if (product is null)
        {
            throw new ProductException("Producto no encontrado.");
        }

        return product;
    }
}