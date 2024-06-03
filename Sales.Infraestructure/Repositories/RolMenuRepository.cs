using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class RolMenuRepository : Repository<RolMenu>, IRolMenuRepository
{
    private readonly SalesContext _context;

    public RolMenuRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}