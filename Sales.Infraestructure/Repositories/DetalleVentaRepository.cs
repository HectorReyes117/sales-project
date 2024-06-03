using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class DetalleVentaRepository : Repository<DetalleVenta>, IDetalleVentaRepository
{
    private readonly SalesContext _context;

    public DetalleVentaRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}