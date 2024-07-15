using Microsoft.AspNetCore.Http;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class MenuRepository : Repository<Menu>, IMenuRepository
{
    private readonly SalesContext _context;
    
    public MenuRepository(SalesContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
    {
        this._context = context;
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