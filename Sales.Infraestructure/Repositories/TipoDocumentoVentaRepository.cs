using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class TipoDocumentoVentaRepository : Repository<TipoDocumentoVenta>, ITipoDocumentoVentaRepository
{
    private readonly SalesContext _context;

    public TipoDocumentoVentaRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}