using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Common.Extensions;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly SalesContext _context;

    public ProductoRepository(SalesContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
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
                    NombreCategoria = product.Categoria.Descripcion,
                    EsActivo = product.EsActivo,
                    Precio = product.Precio,
                    UrlImagen = product.UrlImagen,
                    Descripcion = product.Descripcion,
                    Eliminado = product.Eliminado,
                    IdCategoria = product.Categoria.Id
                }
        ).ToListAsync();
        
        return products;
    }
    
    public override async Task Save(Producto entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        
        if (await base.Exist(ct => ct.Descripcion == entity.Descripcion))
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
    
    public async Task DeleteProduct(int id)
    {
        Producto? product = await this.Get(id);
        product!.FechaElimino = DateTime.Now;
        product!.Eliminado = true;
        await Update(product);
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        var product = await base.Get(id);

        if (product is null)
        {
            throw new ProductException("Producto no encontrado.");
        }
        
        var category = await _context.Categoria.FindAsync(product!.IdCategoria);
        var newProduct = product.MapTo<ProductModel>();
        newProduct.NombreCategoria = category.Descripcion;
        return newProduct;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _context.Productos.Where(x => x.Eliminado == false)
            .Include(x => x.Categoria)
            .Select(product => new ProductModel()
            {
                Id = product.Id,
                CodigoBarra = product.CodigoBarra,
                Marca = product.Marca,
                Stock = product.Stock,
                NombreCategoria = product.Categoria.Descripcion,
                EsActivo = product.EsActivo,
                Precio = product.Precio,
                UrlImagen = product.UrlImagen,
                Descripcion = product.Descripcion,
                Eliminado = product.Eliminado,
                IdCategoria = product.Categoria.Id
                
            }).ToListAsync();
        return products;
    }
    
    public override string[] FullTextSearchColumns()
    {
        return [];
    }

    public override string[] FilterableColumns()
    {
        return [];
    }
}