using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly SalesContext _context;

    public ProductoRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}