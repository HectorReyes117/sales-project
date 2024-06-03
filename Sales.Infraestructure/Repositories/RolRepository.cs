using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class RolRepository : Repository<Rol>, IRolRepository
{
    private readonly SalesContext _context;

    public RolRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}