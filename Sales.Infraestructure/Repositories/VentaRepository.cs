using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class VentaRepository : Repository<Venta>, IVentaRepository
{
    private readonly SalesContext _context;

    public VentaRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}