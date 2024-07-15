using Microsoft.AspNetCore.Http;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class RolRepository : Repository<Rol>, IRolRepository
{
    private readonly SalesContext _context;

    public RolRepository(SalesContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
    {
        _context = context;
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