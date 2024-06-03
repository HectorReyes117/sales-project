using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class MenuRepository : Repository<Menu>, IMenuRepository
{
    private readonly SalesContext _context;
    
    public MenuRepository(SalesContext context) : base(context)
    {
        this._context = context;
    }
}