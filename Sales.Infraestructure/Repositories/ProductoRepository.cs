using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;

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
}